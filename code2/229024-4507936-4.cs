    class MyConsole
    {
        private static TextReader reader = System.Console.In;
        private static TextWriter writer = System.Console.Out;
    
        public static void SetReader(TextReader reader)
        {
            if (reader == null)
            {
                throw new ArgumentNullException("reader");
            }
            MyConsole.reader = reader;
        }
    
        public static void SetWriter(TextWriter writer)
        {
            if (writer == null)
            {
                throw new ArgumentNullException("writer");
            }
            MyConsole.writer = writer;
        }
    
    
        public static string ReadLine()
        {
            return reader.ReadLine();
        }
        public static string ReadLine(string message)
        {
    
            writer.WriteLine(message);
            return ReadLine();
        }
        // and so on
    }
