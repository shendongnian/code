    var results = items.OrderBy(x => x.Created)
                       .Where(x => x.GetType().GetProperty("IsDeadly") !=null)
                       .Select( x => 
                        {
                          dynamic o = x;
                          return new { IsDeadly = o.IsDeadly, Created = o.Created }; 
                        })
                       .ToList();
