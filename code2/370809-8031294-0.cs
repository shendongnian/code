    Uri uri = new Uri("tile.jpg", UriKind.Relative);
    StreamResourceInfo sri = Application.GetResourceStream(uri);
    
    WriteableBitmap wbm = new WriteableBitmap(173, 173);
    wbm.SetSource(sri.Stream);
    
    using (var stream = IsolatedStorageFile.GetUserStoreForApplication().CreateFile("/Shared/ShellContent/tile.png"))
    {
        wbm.SaveJpeg(stream, 173, 173, 0, 100);
    }
    
    var data = new StandardTileData();
    data.BackgroundImage = new Uri("isostore:/Shared/ShellContent/tile.png", UriKind.Absolute);
    data.Title = "updated image";
    
    var tile = ShellTile.ActiveTiles.First();
    tile.Update(data);
