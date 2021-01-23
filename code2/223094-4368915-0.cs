    using (var reader = new StreamReader("foo.txt"))
    {
        if (reader.BaseStream.Length > 1024)
        {
            reader.BaseStream.Seek(-1024, SeekOrigin.End);
        }
        string line;
        while ((line = reader.ReadLine()) != null)
        {
            Console.WriteLine(line);
        }
    }
