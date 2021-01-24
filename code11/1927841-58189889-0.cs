    var ans = flats.GroupBy(f => f.Group1)
                   .Select(fg => new Group1 {
                                    Name = fg.Key,
                                    Group2 = fg.GroupBy(f => f.Group2).Select(fg2 => new Group2 {
                                                                                Name = fg2.Key,
                                                                                Values = fg2.Select(f => f.Value).ToArray()
                                                                              })
                                                                       .ToArray()
                           })
                   .ToArray();
