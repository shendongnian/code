    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Text.RegularExpressions;
    namespace ConsoleApplication108
    {
        class Program
        {
            static void Main(string[] args)
            {
                Box a = new Box(1, 1, 1);
                Box b = new Box(2, 2, 2);
                int c = a.CompareTo(b);
     
            }
        }
        public class Box : IComparable
        {
            public Box() { }
            public Box(int h, int l, int w)
            {
                this.Height = h;
                this.Length = l;
                this.Width = w;
            }
            public int Height { get; private set; }
            public int Length { get; private set; }
            public int Width { get; private set; }
            public int CompareTo(object obj)
            {
                 return CompareTo((Box)obj);
            }
            public int CompareTo(Box other)
            {
                int results = this.Height.CompareTo(other.Height);
                if (results != 0)
                {
                    results = this.Length.CompareTo(other.Length);
                    if (results != 0)
                    {
                        results = this.Width.CompareTo(other.Width);
                    }
                }
                return results;
            }
        }
      
    }
