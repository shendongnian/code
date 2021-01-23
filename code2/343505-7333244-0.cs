    using (var reader = new System.IO.StreamReader(@"C:\file.txt"))
    {
        while (!reader.EndOfStream)
        {
            var line = reader.ReadLine();
    
            if (line.StartsWith("info"))
            {
                // do something
            }
        }
        reader.Close();
    }
