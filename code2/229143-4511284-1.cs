    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.GetEncoding(1252);
            Console.WriteLine((char) 169);
            Console.WriteLine((char) 170);
    
            for(char c = (char)179; c <= (char)218; ++c)
            {
                Console.WriteLine(c);
            }
        }
    }
