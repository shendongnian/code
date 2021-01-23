    var res = sentence.Split()
                      .Concat(sentence2.Split())
                      .Aggregate(new Dictionary<string, int>(),
                                 (a, x) => {
                                               int count;
                                               a.TryGetValue(x, out count);
                                               a[x] = count + 1;
                                               return a;
                                           },
                                 a => a.Select(x => new {
                                                            TheWord = x.Key,
                                                            Occurrence = x.Value
                                                        }));
