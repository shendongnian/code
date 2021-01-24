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
