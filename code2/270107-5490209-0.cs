    outerJoin = outerJoin.Concat(lastNames.Select(l=>new
                                {
                                    id = l.ID,
                                    firstname = String.Empty,
                                    surname = l.Name
                                }).Where(l=>!outerJoin.Any(o=>o.id == l.id)));
                      
