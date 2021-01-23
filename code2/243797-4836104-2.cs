    using System;
    using System.Text;
    using System.Text.RegularExpressions;
    
    namespace Test
    {
        class Program
        {
            static void Main(string[] args)
            {
                string str = "The quick brown fox jumps over the lazy dog";
    
                Regex regex = new Regex(@"\w+", RegexOptions.Compiled);
    
                
                for (Match match = regex.Match(str); match.Success; match = match.NextMatch())
                {
                    Console.WriteLine(match.Value);
                }
            }
        }
    }
