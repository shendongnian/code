    using System;
    using System.Text;
    
    namespace ConsoleApp1
    {
        internal static class Program
        {
            private static void Main(string[] args)
            {
                var value = 9119;
    
                if (!TrySquare(value, out var result))
                {
                    Console.WriteLine("Failed!");
                    return;
                }
    
                Console.WriteLine(result);
            }
    
            private static bool TrySquare(int value, out int result)
            {
                result = 0;
    
                var builder = new StringBuilder();
    
                var input = value.ToString();
    
                foreach (var c in input)
                {
                    var i = int.Parse(c.ToString());
    
                    builder.Append(i * i);
                }
    
                // this might fail if number is too large
    
                return int.TryParse(builder.ToString(), out result);
            }
        }
    }
