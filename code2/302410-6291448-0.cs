    var query = from a in context.EntitiesA
                select new 
                   {
                      a.Id,
                      a.Name,
                      Bs = a.EntityB.Select(b => new { 
                           b.StuffToBeLoaded1, 
                           b.StuffToBeLoaded2 
                      })
                   };
