    var query = 
        from DataRow row in results.Rows
        // here the query stuff you already had
        select new { rollno, section, exam, remarks };
    // 1. Grouping
    var groups =
        from item in query
        group item by item.section into g
        select new
        {
            Section = g.Key,
            Rollnos = group.Select(i => i.rollno).ToArray(),
        };
    // 2. Presentation
    foreach (var group in groups)
    {
        Console.WriteLine(group.Section);
        Console.WriteLine(string.Join(" ", group.Rollno));
    }
