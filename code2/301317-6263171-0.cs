    from p in ListofModel
    group p by new { p.ClientNo, p.Date, p.Name } into g
    orderby g.key.Date
    select new ModelClass
    {
        ClientNo = g.Key.ClientNo,
        Name = g.key.Name,
        Date = g.Key.Date,
        Time = g.Sum(x => x.Time)
    }
