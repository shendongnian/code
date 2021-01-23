     var sum = fooList.Where(f => f.Id == 1 || f.Id == 2)
                      .Aggregate(new FooAmounts(), // Seed
                                 (sum, item) => {
                                     sum.Month1 += item.Month1;
                                     sum.Month2 += item.Month2;
                                     ...
                                     return sum;
                                 });
