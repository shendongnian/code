        private void RefreshApplicationTile()
        {
            ShellTile tile = ShellTile.ActiveTiles.First();
            if (tile != null) {
                StandardTileData NewTileData = new StandardTileData
                {
                    Title = String.Empty,
                    BackgroundImage = new Uri(@"/Background.png", UriKind.Relative),
                    BackTitle = String.Empty,
                    BackBackgroundImage = new Uri(@"/BackBackground.png", UriKind.Relative),
		....
                };
                tile.Update(NewTileData);
            }
        }
