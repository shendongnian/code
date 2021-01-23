    //a big array - have to start somewhere
    int[] source = Enumerable.Range(0, 1000000).ToArray();
    var query1 = source.Where(i => i % 2 == 1); //500000 elements
    var query2 = query1.Select(i => i.ToString()); //500000 elements
    var query3 = query2.Where(i => i.StartsWith("2"); //50000? elements
    var query4 = query3.Take(5); //5 elements
    string[] result = query4.ToArray();
