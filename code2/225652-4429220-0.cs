    var query = 
        from DataRow row in results.Rows
        // here the query stuff you already had
        select new { rollno, section, exam, remarks };
    // 1. Grouping
    var groups =
        from item in query
        group item by item.rollno into g
        select new
        {
            Rollno = g.Key,
            Sections = group.Select(i => i.section).ToArray(),
        };
    // 2. Presentation
    foreach (var group in groups)
    {
        Console.WriteLine(group.Rollno);
        Console.WriteLine(string.Join(" ", group.Sections));
    }
