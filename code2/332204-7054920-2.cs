    static void Main(string[] args)
    {
        using (StreamWriter writer = new StreamWriter("C:/Users/Rafael/desktop/newfile.txt"))
        using (StreamReader reader = new StreamReader("C:/Users/Rafael/desktop/new1.txt"))
        {
            string line;
            while ((line = reader.ReadLine()) != null)
            {
                writer.WriteLine(line);
            }
        }
    }
