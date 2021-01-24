    List<ChartData> allItems = GetDataForChart("somefunctionIguess");
    List<List<ChartData>> sublists = new List<List<ChartData>>();
    sublists = 
    allItems.GroupBy( x => new {
         x.Timestamp.Date,
         x.Timestamp.Hour
    })
    .Select(x=> x.ToList()).ToList();
