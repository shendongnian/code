    var data = new[]{
    new { Id = "6752 JT", Date = new DateTime(2011, 1, 12), Num = 3690 },
    new { Id = "6752 JT", Date = new DateTime(2011, 1, 13), Num = 3600 },
    ...,
    };
    var query = data.OrderBy(o => o.Date).GroupBy(o => o.Id);
