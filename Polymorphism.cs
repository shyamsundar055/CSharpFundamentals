using System;

namespace CSharpFundamentals
{
    public class Polymorphism
    {
        #region Implementations of Dynamic or Runtime or Late binding (Virtual/Overriding) 
        //Base class
        public class Shape
        {
            public int X { get; private set; }
            public int Y { get; private set; }

            // Virtual members
            public virtual int Height { get; set; }
            public virtual int Width { get; set; }

            // Virtual methods
            public virtual void Draw()
            {
                Console.WriteLine("Draw from base class");
            }

            public void CalculateDimensions()
            {
                Console.WriteLine("CalculateDimensions from base class");
            }
        }

        //Derived class
        public class Circle : Shape
        {
            //Override members
            public override int Height { get; set; }
            public override int Width { get; set; }

            //Override methods
            public override void Draw()
            {
                Console.WriteLine("Drawing a circle");
                base.Draw(); // invoke base class method using "base" keyword
            }

            //Method hiding using new keyword
            public new void CalculateDimensions()
            {
                Console.WriteLine("CalculateDimensions from derived class - Method hiding"); 
            }
        }

        //Derived class
        public class Rectangle : Shape
        {
            public override int Height { get; set; }
            public override int Width { get; set; }

            //Prevent further derived classes from overriding using "sealed" keyword
            public sealed override void Draw()
            {
                Console.WriteLine("Drawing a rectangle"); 
            }
        }
        #endregion

        #region Implementations of Static or Compile time or Early binding (Method/Operator overloading)
        public class Calculator
        {
            public int Total { get; set; }

            //Operator overloading
            //1.Should be public static
            //2.Unary operator has one input parameter
            //3. Binary operator has two input parameters
            public static Calculator operator +(Calculator a, Calculator b)
            {
                Console.WriteLine("Operator overload - sum of two objects");
                return new Calculator
                {
                    Total = a.Total + b.Total
                };
            }
    
            //Method overloading
            public void Add(int a, int b, int c)
            {
                Total = a+b+c;
                Console.WriteLine($"Add method 1 - Total is {Total}");
            }
            public void Add(int a, int b)
            {
                Total = a + b;
                Console.WriteLine($"Add method 2 - Total is {Total}");
            }
        }

        #endregion

        public Polymorphism()
        {
            #region Output of Dynamic or Runtime or Late binding (Virtual/Overriding)
            // Create of list of derived class objects using base type
            List<Shape> shapes = new List<Shape>
            {
                new Rectangle(), 
                new Circle()
            };

            //Overriden method is invoked
            foreach (var shape in shapes)
            {
                shape.Draw();
            }

            /* Output:
            Drawing a rectangle
            Draw from base class 
            Drawing a circle 
            */

            Console.WriteLine();

            //Invoke method hiding
            Circle circle = new Circle();
            circle.CalculateDimensions();

            /* Output: 
            CalculateDimensions from derived class - Method hiding 
            */
            #endregion



            #region Output of Static or Compile time or Early binding (Method/Operator overloading)
            Calculator calculator = new Calculator();
            calculator.Add(1, 2, 3);
            calculator.Add(1, 2);


            Calculator calculatorA = new Calculator();
            calculatorA.Add(1, 2, 3);

            Calculator calculatorB = new Calculator();
            calculatorB.Add(4, 5, 6);

            Calculator calculatorC = calculatorA + calculatorB;
            Console.WriteLine($"Total of calculatorC - {calculatorC.Total}");
            #endregion

        }
    }
}
