    var result = _context.MyTable.AsQueryable()
                .Join(_context.SecondTable,
                    p => p.UnicId,   // these columns are equal p.UnicId == c.UnicId
                    c => c.UnicId,
                    (p, c) => new Models.NewTable()
                    { 
                        Id=p.UnicId,
                        UnicId=p.UnicId,
                        Name=p.Name,
                        Names=c.Names
                    });
