    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    namespace ConsoleApplication107
    {
        class Program
        {
            static void Main(string[] args)
            {
                List<Point> points = new List<Point>() {
                    new Point() { Color = "Red", X = 5, Y = 7},
                    new Point() { Color = "Blue", X = 6, Y = 5},
                    new Point() { Color = "Red", X = 2, Y = 4},
                    new Point() { Color = "Blue", X = 3, Y = 0},
                    new Point() { Color = "Red", X = 0, Y = 0},
                    new Point() { Color = "Blue", X = 0, Y = 5},
                    new Point() { Color = "Yellow", X = 1, Y = 4},
                    new Point() { Color = "Yellow", X = 2, Y = 3},
                    new Point() { Color = "Yellow", X = 1, Y = 1}
                };
                //create link list
                LinkedList<Point> list = new LinkedList<Point>();
                foreach (Point point in points)
                {
                    list.AddLast(point);
                }
                var results = list.GroupBy(x => x.Color).Select(x => new { color = x.Key, perimeter = x.Select(y => new { X = y.X, Y = y.Y }).ToList() }).ToList();
            }
        }
        public class Point
        {
            public string Color { get; set; }
            public int X { get; set; }
            public int Y { get; set; }
        }
    }
