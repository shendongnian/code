    var sb = new StringBuilder();
    using (var ctx = new Ctx())
    {
        ctx.CommandTimeout = 10000; // Perhaps not necessary anymore
        var allClasses = ctx.Classes.Include("Students").OrderBy(o => o.Id)
            .ToList(); // executes query, allClasses is now a List, not an IQueryable
        // everything from here runs in memory
        foreach (var c in allClasses)
        {
            var duplicates = allClasses.Where(
               o => o.SubjectId == c.SubjectId &&
               o.Id != c.Id &&
               o.Students.OrderBy(s => s.Name).Select(s => s.Name)
                .SequenceEqual(c.Students.OrderBy(s => s.Name).Select(s => s.Name)));
            
            // duplicates is an IEnumerable, not an IQueryable
            foreach (var d in duplicates)
                sb.Append(d.LongName)
                  .Append(" is a duplicate of ")
                  .Append(c.LongName)
                  .Append("<br />");
        }
    }
    lblResult.Text = sb.ToString();
