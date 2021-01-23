    using System;
    using System.Text;
    
    namespace ReplaceNoRegex
    {
        class Program
        {
            static void Main(string[] args)
            {
                Console.WriteLine(ReplaceWithX("12345678"));
                Console.WriteLine(ReplaceWithXLeave4("12345678"));
            }
    
            static string ReplaceWithX(string input)
            {
                return Repeat('x', input.Length);
            }
    
            static string ReplaceWithXLeave4(string input)
            {
                if (input.Length <= 4)
                    return input;
    
                return Repeat('x', input.Length - 4)
                     + input.Substring(input.Length - 4);
            }
    
            static string Repeat(char c, int count)
            {
                StringBuilder xs = new StringBuilder(count);
    
                for (int i = 0; i < count; ++i)
                    xs.Append(c);
    
                return xs.ToString();
            }
        }
    }
