    using System;
    using System.Text.RegularExpressions;
    
    namespace ConsoleApplication1
    {
        class Program
        {
            static string spintax(Random rnd, string str) {
                // Loop over string until all patterns exhausted.
                string pattern = "{[^{}]*}";
                Match m = Regex.Match(str, pattern);
                while (m.Success) {
                    // Get random choice and replace pattern match.
                    string seg = str.Substring(m.Index + 1, m.Length - 2);
                    string[] choices = seg.Split('|');
                    str = str.Substring(0, m.Index) + choices[rnd.Next(choices.Length)] + str.Substring(m.Index + m.Length);
                    m = Regex.Match(str, pattern);
                }
    
                // Return the modified string.
                return str;
            }
            static void Main(string[] args) {
                Random rnd = new Random();
                string str = "{Hello|Hi} {World|People}! {C{#|++|}|Java} is an {awesome|amazing} language.";
                Console.WriteLine(spintax(rnd, str));
                Console.ReadLine();
            }
        }
    }
