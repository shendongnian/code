    using System;
    using System.Text.RegularExpressions;
    
    namespace MatchEvaluatorTest
    {
        class Program
        {
            static void Main(string[] args)
            {
                string text = "The cat jumped over the dog.";
                Console.WriteLine(text);
                Console.WriteLine(Transform(text));
            }
    
            static string Transform(string text)
            {
                return Regex.Replace(
                    text,
                    @"\b\w{3}\b",
                    m => Replacement(m.Captures[0].Value)
                );
            }
    
            static string Replacement(string s)
            {
                return string.Format("*{0}*", s.ToUpper());
            }
        }
    }
