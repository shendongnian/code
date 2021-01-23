    using (TextReader reader = File.OpenText(@"c:\bigfile.txt"))
    {
        using (TextWriter writer = File.CreateText(@"C:\bigfilelinebreak.txt"))
        {
            char[] buffer = new char[40];
            int charsRead;
            while ((charsRead = reader.ReadBlock(reader, buffer, buffer.Length)) > 0)
            {
                writer.Write(buffer, 0, charsRead);
                writer.WriteLine();
            }
        }
    }
