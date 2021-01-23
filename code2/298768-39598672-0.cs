    class Program
    {
        static void Main(string[] args)
        {
            String unicodeString =
            "This Unicode string contains two characters " +
            "with codes outside the traditional ASCII code range, " +
            "Pi (\u03a0) and Sigma (\u03a3).";
            Console.WriteLine("Original string:");
            Console.WriteLine(unicodeString);
            UnicodeEncoding unicodeEncoding = new UnicodeEncoding();
            byte[] utf16Bytes = unicodeEncoding.GetBytes(unicodeString);
            char[] chars = unicodeEncoding.GetChars(utf16Bytes, 2, utf16Bytes.Length - 2);
            string s = new string(chars);
            Console.WriteLine();
            Console.WriteLine("Char Array:");
            foreach (char c in chars) Console.Write(c);
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("String from Char Array:");
            Console.WriteLine(s);
            Console.ReadKey();
        }
    }
