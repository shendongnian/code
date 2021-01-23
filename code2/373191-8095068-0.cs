    using (var reader = new System.IO.StreamReader("MyFile.txt"))
    {
        while(!reader.EndOfStream)
        {
            string line = reader.ReadLine();
            if (line.Contains(pattern))
                counter++;
        }
    }
