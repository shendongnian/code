    var tilesToRender = allTiles.Where(x => !x.Color.HasValue).ToList();
    Color newColor = Color.FromName("Red"); // However you source the color to use...
    using(var brush = new SolidBrush(newColor))
    {
        foreach(var tile in tilesToRender)
        {
            tile.Color = newColor;
            e.Graphics.FillRectangle(brush, tile.Rect); // or appropriate paint method...
        }
    }
    var otherTiles = allTiles.Except(tilesToRender).GroupBy(x => x.Color).ToList();
    foreach(var colorGroup in otherTiles)
    {
        Color color = colorGroup.Key;
        using(var brush = new SolidBrush(color))
        {
            foreach(var tile in tilesToRender)
            {
                e.Graphics.FillRectangle(brush, tile.Rect); // or appropriate paint method...
            }
        }
    }
