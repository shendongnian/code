    var position = new Dictionary<string, int>
    {
        { "Europe", 0 },
        { "Africa", 1 },
        { "America", 2 },
    };
    var categories = catList.Select(c => new ...);
                            .OrderBy(x => position[x.Title])
                            .ThenBy(x => x.Title);
