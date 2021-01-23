    int columnCount = columnList[0].Count;
    int rowCount = columnList.Count;
    var rowList =  Enumerable.Range(0, columnCount)
                             .Select( x => Enumerable.Range(0, rowCount)
                                                     .Select(y => columnList[y][x])
                                                     .ToList())
                             .ToList();
