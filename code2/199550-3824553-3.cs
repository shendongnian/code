    var people = new[]
    {
        new { Id = 1, Name = "John" },
        new { Id = 2, Name = "Mark" },
        new { Id = 3, Name = "George" }
    };
    
    var sb = people.Aggregate(new StringBuilder(),
                 (s, p) => s.AppendFormat("{0}:{1}, ", p.Id, p.Name));
    sb.Remove(sb.Length - 2, 2); // remove the trailing comma and space
    var last = people.Last();
    // index to last comma (-2 accounts for ":" and space prior to last name)
    int indexComma = sb.Length - last.Id.ToString().Length - last.Name.Length - 2;
    sb.Remove(indexComma - 1, 1); // remove last comma between last 2 names
    sb.Insert(indexComma, "and ");
    
    // 1:John, 2:Mark and 3:George
    Console.WriteLine(sb.ToString());
