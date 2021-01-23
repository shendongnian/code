    var query = db.Table1
        .Join(db.Table2, table1 => table1.Id, table2 => table2.Id, (t1, t2) => new { 
            Id = t2.Id, 
            Name = t2.Name, 
            Total = (t1.Column1 + t1.Column2 + t1.Column3), 
            Date = t1.Date //you didn't use a table alias for this field, so I'm not sure which table it comes from
            })
        .Where(x => x.Date >= new DateTime(2011, 11, 9)
                    && x.DateCreated <= new DateTime(2011, 11, 9, 23, 59, 59))
        .Join(db.Table3, x => x.Id, table3 => table3.Id, (x, t3) => new {
            Id = x.Id,
            Name = x.Name,
            x.Total
        })
        .Where(x => x.Id == 1)
        .OrderByDescending(x => x.Total)
	    .ThenBy(x => x.Name)
        .Take(10)
        .ToList()
