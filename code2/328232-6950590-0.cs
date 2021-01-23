    var columnList= new  List<List<double>>();
    columnList.Add(new List<double>() { 1, 2, 3 });
    columnList.Add(new List<double>() { 4, 5, 6 });
    columnList.Add(new List<double>() { 7, 8, 9 });
    columnList.Add(new List<double>() { 10, 11, 12 });
    int columnCount = columnList[0].Count;
    var rowList = columnList.SelectMany(x => x)
                            .Select((x, i) => new { V = x, Index = i })
                            .GroupBy(x => (x.Index + 1) % columnCount)
                            .Select(g => g.Select( x=> x.V).ToList())
                            .ToList();
