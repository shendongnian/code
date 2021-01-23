    var list = new List<Course>
    {
        new Course { Abbreviation = "ACCT", Number = 100, Section = "1" },
        new Course { Abbreviation = "ACCT", Number = 100, Section = "2" },
        new Course { Abbreviation = "BUS", Number = 101, Section = "1" },
        ...
    };
    
    var query = from c in list
                group c by new { c.Abbreviation, c.Number } into g
                select string.Format("\"{0}\", {1}, \"{2}\"",
                                     g.Key.Abbreviation,
                                     g.Key.Number,
                                     String.Join(", ", g.Select(c => c.Section).ToArray()));
    List<string> result = query.ToList();
