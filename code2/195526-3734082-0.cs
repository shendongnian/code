    static void Main(string[] args)
    {
        string buffer = string.Empty;
        StreamReader reader = new StreamReader(@"e:\a.csv");
        do
        {
            buffer = reader.ReadLine();
            if (buffer.Contains(";"))
            {
    
                string[] str = buffer.Split(';');
                if (str[0] == "1")
                {
                    Console.WriteLine("ok");
                    break;
                }
            }
        }
        while (!reader.EndOfStream);
    }
