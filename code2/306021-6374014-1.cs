    var list =  db.Tables 
                  .OrderByDescending(t => t.DateReceived)
                  .Take(100) 
                  .Select(t => new MyProjection 
                       {
                           SomeField = t.SomeField,
                           SomeField2 = t.SomeField2
                       })
                  .ToList();
