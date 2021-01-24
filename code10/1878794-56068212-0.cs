    using System;
    
    namespace ConsoleApp4
    {
        class Program
        {
            static void Main(string[] args)
            {
                var input = "chicken crossing the road";
    
                foreach (var item in input.Split(' '))
                {
                    if (item.Contains('e'))
                    {
                        Console.Write(item + ' ');
                    }
                    else
                    {
                        Console.Write(Reverse(item) + ' ');
                    }
                }
            }
    
            public static string Reverse(string s)
            {
                char[] charArray = s.ToCharArray();
                Array.Reverse(charArray);
                return new string(charArray);
            }
        }
    }
