    var limitedUsers = from p in dc.Products
                       group p by p.UserName into g
                       select new
                       {
                         UserName = g.Key,
                         Products = g.Take(dc.UserLimits
                                             .Where(u => u.UserName == g.Key)
                                             .Single().DisplayLimit)
                       };
   
