    var data = (from c in context.Customer
                join o in context.Orders on c.Id equals o.CustomerId into subs
                from sub in subs.DefaultIfEmpty()
                select new 
                {
                     c.Id,
                     c.Name,
                     sub == null ? null : sub.UniquRef
                }).ToList();
    var result = (from d in data 
                  group d by new { d.Id, d.Name } into gr
                  select new 
                  {
                      gr.Key.Id,
                      gr.Key.Name, 
                      AllOrdersRef = (gr.Count() == 1 && gr.First() == null) ? null
                                        : String.Join(", ", gr.Select(x => x.UniquRef))
                  });
