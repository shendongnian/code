    var data = (from c in context.Customer
                join o in context.Orders on c.Id equals o.CustomerId into subs
                from sub in subs.DefaultIfEmpty()
                select new 
                {
                     c.Id,
                     c.Name,
                     UniquRef = sub == null ? null : sub.UniquRef
                }).ToList();
    var result = data.GroupBy(x => new { x.Id, x.Name }).Select(x => new 
                 {
                     x.Key.Id,
                     x.Key.Name, 
                     AllOrdersRef = (x.Count() == 1 && x.First().UniquRef == null) ? null
                                        : String.Join(", ", x.Select(y => y.UniquRef))
                 });
