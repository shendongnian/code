    using System;
    using System.Text;
    
    public class Test
    {
        public static void Main()
        {
            string oldText = "c9e49869a1483v4d9b4ab7d394a328d7d8a3";
            string newText = ReplaceByIndex(oldText, '\'', 3, 9, 14);
            Console.WriteLine(newText);
        }
        
        static string ReplaceByIndex(string text, char newValue, params int[] indexes)
        {
            var builder = new StringBuilder(text);
            foreach (var index in indexes)
            {
                builder[index] = newValue;
            }
            return builder.ToString();
        }
    }
