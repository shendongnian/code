    var customers = context.Customer.Select(x => new { x.Id, x.Name }).ToList();
    var ids = customers.Select(x => x.Id).ToList();
    var orders = context.Orders.Where(x => ids.Contains(x.CustomerId))
                   .Select(x => new { x.UniquRef, x.CustomerId }).ToList();
    
    var data = from c in customers 
               join o in orders on c.Id equals o.CustomerId into subs
               from sub in subs.DefaultIfEmpty()
               group sub by new { c.Id, c.Name } into gr
               select new 
               {
                   gr.Key.Id,
                   gr.Key.Name, 
                   AllOrdersRef = (gr.Count() == 1 && gr.First() == null) ? null
                                        : String.Join(", ", gr.Select(x => x.UniquRef))
               };
