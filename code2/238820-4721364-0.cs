    IQueryable<Problem> problems = db.Problems;
    int count = problems.Count();
    List<Problem> sheet = new List<Problem>(n);
    Random rand = new Random();
    while(sheet.Count < n) {
        var next = problems.OrderBy(p => p.ID).Skip(rand.Next(count))
            .FirstOrDefault();
        if(next != null && !sheet.Any(p => p.ID == next.ID) {
            sheet.Add(next);
        }
    }
?
