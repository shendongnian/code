    List<string> list1 = new List<string> { "A", "B", "C" };
    List<string> list2 = new List<string> { "a", "b", "c", "d" };
    
    
    var result = (from x in list1
                  from y in list2
                  select new
                  {
                      Col1 = x,
                      Col2 = y
                  }).ToList();
    
    
    Console.WriteLine("Col1 \t Col2");
    
    result.ForEach(x => Console.WriteLine(x.Col1 + "\t" + x.Col2));
    
    Console.ReadLine();
