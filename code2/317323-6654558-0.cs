    using System;
    using System.Text;
    
    class Program
    {
        static void Main(string[] args)
        {
            byte[] data = { 0, 0 };
            Encoding latin1 = Encoding.GetEncoding(28591);
            
            string text = latin1.GetString(data);
            Console.WriteLine(text.Length); // 2
            Console.WriteLine((int) text[0]); // 0
            Console.WriteLine((int) text[1]); // 0
        }
    }
