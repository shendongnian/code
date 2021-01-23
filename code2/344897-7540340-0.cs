        private void ResetLiveTileToNormal()
        {
            ShellTile TileToFind = ShellTile.ActiveTiles.FirstOrDefault();
            ShellTileData shellData = new StandardTileData
            {
                Title = "XXXXXXXX",
                Count = 0,
                BackContent = "",
                BackTitle = "",
                BackBackgroundImage = new Uri("", UriKind.Relative),
                BackgroundImage = new Uri(@"/Images/LiveTiles/XXXXXX.png", UriKind.Relative)
            };
            TileToFind.Update(shellData);
        }
