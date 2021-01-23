    int offset = 395;
    int length = 20;
    using (StreamReader sr = new StreamReader(@"\\t.txt"))
    {
        while (!sr.EndOfStream)
        {
            string line = sr.ReadLine();
            string myData = line.Substring(offset, length);
        }
    }
