      var Query = list.GroupBy(
                     (item => item.DateTime),
                     (key, elements) => new  { 
                                              key = key,
                                              count = elements
                                                      .Distinct()
                                                      .Count()
                                             }
                     );
