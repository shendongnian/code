    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    namespace ConsoleApplication1
    {
        class Program
        {
            static void Main(string[] args)
            {
                Decimal number = new Decimal() { number = 12345 };
                string output = number.ToString();
            }
        }
        public class Decimal
        {
            public int number { get; set; }
            public override string ToString()
            {
                string output = string.Format("[{0}][{1}][{2}]",
                    (number & 0xFF).ToString("X2"),
                    ((number >> 8) & 0xFF).ToString("X2"),
                    ((number >> 16) & 0xFF).ToString("X2"));
                return output;
            }
        }
    }
