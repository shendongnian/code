    var listInfo = (from i in context.Billings
                    where i.UsreId== id
                    group i by new
                    { i.UsreId } into newInfo
                    select new 
                    {
                       UserId,
                       Month,
                       Type,
                       Description,
                       Total= Amount.Count()
                       
                    }).AsEnumerable();
