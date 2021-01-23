    IEnumerable<Cat> cats = //.. get all cats here
    if (filter.FilterByColor)
       cats = cats.Where(c=>c.Color = filter.Color);
   
    if (filter.FilterByName)
       cats = cats.Where(c=>c.Name = filter.Name);
    if (filter.FilterByDate)
       cats = cats.Where(c=>c.Date > filter.FromDate && c.Date < filter.ToDate)
    return cats.ToList(); // finally filter data and return them.
