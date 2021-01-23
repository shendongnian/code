    // Create 20 dummy items.
    var albums = Enumerable.Range(1, 20)
        .Select(i => string.Format("Album {0}", i));
    // Associate each one with the row index.
    var numbered = albums
        .Select((item, index) =>
            new { Row = index / 3, Item = item });
    // Arrange into columns.
    var table = numbered
        .GroupBy(x => x.Row)
        .Select(g => g.Select(x=>x.Item).AsEnumerable());
