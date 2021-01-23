    var result = collection.GroupBy(i => i.ParentName)
               .Select(g => new {
                                    ParentName = g.Key, 
                                    SimplePocos = g.Select(i => new SimplePoco
                                                                    {
                                                                     Name = i.Name, 
                                                                     Url = i.Url
                                                                     })
                                  });  
 
