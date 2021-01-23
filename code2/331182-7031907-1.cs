    var listLines = new List<string[]>();
    using (var tr = new StringReader(str))
    {
        string l;
        while ((l = tr.ReadLine()) != null)
            listLines.Add(l.Split(new[] {' '}, 
                StringSplitOptions.RemoveEmptyEntries));
    }
