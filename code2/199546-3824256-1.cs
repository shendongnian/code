    var list = new[] { new { ID = 1, Name = "John" },
                       new { ID = 2, Name = "Mark" },
                       new { ID = 3, Name = "George" } };
    var resultAggr = list
        .Select(item => item.ID + ":" + item.Name)
        .Aggregate(new { Sofar = "", Next = (string) null },
                   (agg, next) => new { Sofar = agg.Next == null ? "" :
                                                agg.Sofar == "" ? agg.Next :
                                                agg.Sofar + ", " + agg.Next,
                                        Next = next });
    var result = resultAggr.Sofar == "" ? resultAggr.Next :
                 resultAggr.Sofar + " and " + resultAggr.Next;
    // Prints 1:John, 2:Mark and 3:George
    Console.WriteLine(result);
