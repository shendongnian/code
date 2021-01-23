    from x in values
    group x by new {x.Id, x.Activity} into g
    select new
    {
        Id = g.Key.Id,
        Activity = g.Key.Activity,
        TotalMarks = g.Sum(y => y.Marks)
    };
