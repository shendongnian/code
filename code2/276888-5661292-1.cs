    var listB = new List<string>() { "a", "b", "c", "d", "e" };
    var listA = new List<string>() { "1", "2", "3" };
    var groupings = (from b in listB.Select((b, i) => new
                                            {
                                                Index = i,
                                                Element = b
                                            })
                     group b.Element by b.Index % listA.Count).Zip(listA, (bs, a) => new
                                                                          {
                                                                              A = a,
                                                                              Bs = bs
                                                                          });
    foreach (var item in groupings)
    {
        Console.WriteLine("{0}: {1}", item.A, string.Join(",", item.Bs));
    }
