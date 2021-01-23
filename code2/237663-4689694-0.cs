    using (StreamReader r = new StreamReader(stream))
    using (StreamWriter w = new StreamWriter(someOutputStream))
    {
        string line = r.ReadLine();
        line = DoReplacements(line);
        w.WriteLine(line);
    }
