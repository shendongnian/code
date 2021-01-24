    List<string> elements = new List<string>() //lets consider them as strings
    {
      "tbl1",
      "tbl1",
      "tbl2",
      "tbl3",
      "tbl1",
      "tbl4",
      "tbl2"
    };
    var groups = elements.OrderBy(x=>x).GroupBy(x => x);//group them according to their value
    foreach(var group in groups)
    {
      foreach (var el in group) Console.WriteLine(el);
    }
