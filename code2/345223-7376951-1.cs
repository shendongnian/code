     var sum = fooList.Where(f => f.Id == 1 || f.Id == 2)
                      .Aggregate(new FooAmounts(), // Seed
                                 (sum, item) => new FooAmounts {
                                     Month1 = sum.Month1 + item.Month1,
                                     Month2 = sum.Month2 + item.Month2,
                                     ...
                                 });
