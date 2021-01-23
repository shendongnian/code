    using (StreamReader r = new StreamReader(stream))
    using (StreamWriter w = new StreamWriter(someOutputStream))
    {
        string line = null;
        while ((line = r.ReadLine()) != null)
        {
           line = DoReplacements(line);
           w.WriteLine(line);
        }
    }
