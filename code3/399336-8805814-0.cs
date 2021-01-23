    Dispatcher.BeginInvoke(() =>
    {
        ShellTile appTile = ShellTile.ActiveTiles.First();
 
        if (appTile != null)
        {
             StandardTileData tileData = new StandardTileData
             {
                  BackContent = DateTime.Now.ToString() + message2.ToString()
             };
             appTile.Update(tileData);
             tcs.TrySetResult(true);
        }
        else
        {
             tcs.TrySetResult(true);
        }
    }
