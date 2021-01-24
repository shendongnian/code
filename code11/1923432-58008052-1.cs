    List<MyTable> data = new List<MyTable>()
    {
         new MyTable(){ChangeId = 1, AssetId = 1, Timestamp = 123},
         new MyTable(){ChangeId = 2, AssetId = 2, Timestamp = 999},
         new MyTable(){ChangeId = 3, AssetId = 1, Timestamp = 123},
         new MyTable(){ChangeId = 5, AssetId = 3, Timestamp = 123},
         new MyTable(){ChangeId = 5, AssetId = 2, Timestamp = 123},
    };
    var expectedData = data.OrderByDescending(d => d.Timestamp).GroupBy(d => d.AssetId).Select(g => new
    {
         AssetId = g.Key,
         TimeStamp = g.First().Timestamp
    }).ToList();
