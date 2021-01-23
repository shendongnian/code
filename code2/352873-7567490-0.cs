    List<string> theList = new List<string>() { "00012345.pdf", "00012345.pdf", "12345.pdf", "1234567.pdf", "12.pdf" };
 
    theList.GroupBy(txt => txt)
            .Where(grouping => grouping.Count() > 1)
            .ToList()
            .ForEach(groupItem => Console.WriteLine("{0} duplicated {1} times with these     values {2}",
                                                     groupItem.Key,
                                                     groupItem.Count(),
                                                     string.Join(" ", groupItem.ToArray())));
