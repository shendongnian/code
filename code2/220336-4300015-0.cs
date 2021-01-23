    var query = from r in db.SomeTable
                select new
                {
                    r.Id,
                    r.Name,
                    r.MeterValues,
                    ...
                };
    var temp = from x in query.AsEnumerable()
               select new BusinessObject
               {
                   Id = x.Id,
                   Name = x.Name,
                   MeterValues = x.mv.Split('|').Select(Decimal.Parse).ToArray(),
                   ...
               };
    return temp.ToArray();
