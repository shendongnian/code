    // delegate for generating orderby key    
    Func<RowData, string, int> sortKey = (r, gn) =>
    {
        var game = r.Games.FirstOrDefault(g => g.Name == gn);
        return game != null ? game.Version : int.MaxValue; // or "zzzzz" if version is a string (something to put it to the end of the list)
    };
    List<RowData> result = rows
        .OrderBy(r => sortKey(r, gameName))
        .ToList();
