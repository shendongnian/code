    using System;
    
    class Program
    {
        static void Main(string[] args)
        {
            DateTime now = DateTime.Now;
            string text = now.ToString("o");
            DateTime parsed;
            if (DateTime.TryParseExact(text, "o", null,
                DateTimeStyles.RoundtripKind, out parsed))
            {
                Console.WriteLine(parsed == now);
            }
            else
            {
                Console.WriteLine("Couldn't parse");
            }
        }
    }
