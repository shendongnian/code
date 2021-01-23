    ShellTile tile = ShellTile.ActiveTiles.FirstOrDefault();
    // The first tile is the application tile. 
    // I'm not sure if it will be there if you application is not pinned
    if (tile != null)
    {
        tile.Update(new StandardShellTileData
        {
                Title = "New Tile Title!",
                Count = 50
        });
    }
