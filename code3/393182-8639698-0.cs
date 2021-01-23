      public abstract class Shape
            {
                //Protected konstruktor
                protected Shape(double length, double width)
                {
                    _length = length;
                    _width = width;
                }
        
        
                protected double _length;
                protected double _width;
        
                public abstract double Area
                {
                    get;
                }
            }
            class Ellipse : Shape
            {
              //Konstruktor
              public Ellipse(double length, double width)
                : base(length, width)
              {
        
              }
        
              //Egenskaper
              public override double Area
              {
                get
                {
                  return Math.PI * _length * _width;
                }
              }
            }
