    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    
    namespace ShapesStacjOverflow {
    
    
        public abstract class Shape {
            public abstract double Area();
        }
    
        public class Rectangle : Shape {
            public double Height { get; set; }
            public double Width { get; set; }
            public override double Area() {
                return Height * Width;
            }
        }
    
        public class AreaCalculator {
            public double TotalArea(Shape[] shapes) {
                double area = 0;
                foreach (var objShapes in shapes) {
                    area += objShapes.Area();
                }
                return area;
            }
        }
        class Program {
            static void Main(string[] args) {
                AreaCalculator _obj = new AreaCalculator();
                Shape[] _shapes = new Shape[2];
                Rectangle rectangle1 = new Rectangle {
                    Width = 2,
                    Height = 3
                };
                Rectangle rectangle2 = new Rectangle {
                    Width = 1,
                    Height = 1
                };
                _shapes[0] = rectangle1;
                _shapes[1] = rectangle2;
    
                var _result = _obj.TotalArea(_shapes);
                Console.WriteLine(_result);
                Console.ReadLine();
            }
        }
    }
