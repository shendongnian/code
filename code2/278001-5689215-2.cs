    var result = Enumerable.Range(0, essays.Count() - 1)
        .Select(i => new {Essays1 = essays[i], Essays2 = essays[i + 1]})
        .Where(a => a.Essays2 != null)
        .Where(a => a.Essays2.Date - a.Essays1.Date < new TimeSpan(0, 0, 0, 20))
        .Select(a => a.Essays1);
