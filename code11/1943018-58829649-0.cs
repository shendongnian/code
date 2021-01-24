    using System;
    using System.Text.RegularExpressions;
    
    public class Test
    {
        public static void Main()
        {
            string pattern = @"(?is)\bEmail:\s*([^@]+@[^.]+\.[a-z0-9]{2,6}(?:\.[a-z0-9]{2,6})?)$";
            string input = @"OrderId:009
                Email:Ardi1234@yahoo.com
                ProductId:X206
    
                OrderId:009
                    Email: Ardi1234@yahoo.co.uk
                    ProductId:X206
    
                OrderId:009
                    EMAIL: Ardi1234@yahoo.co.uk
                    ProductId:X206";
            RegexOptions options = RegexOptions.Multiline;
            
            foreach (Match m in Regex.Matches(input, pattern, options))
            {
                Console.WriteLine("'{0}' found at index {1}.", m.Value, m.Index);
            }
        }
    }
