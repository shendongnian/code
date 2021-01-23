    void clearTile() {
                ShellTileData tileData = new StandardTileData
                {
                    Title = "",
                    Count = 0,
                    BackContent = "",
                    BackTitle = "",
                    BackBackgroundImage = new Uri("", UriKind.Relative),
                    BackgroundImage = new Uri(@"/ApplicationIcon.png", UriKind.Relative)
                };
                IEnumerator<ShellTile> it = ShellTile.ActiveTiles.GetEnumerator();
                it.MoveNext();
                ShellTile tile = it.Current;
                tile.Update(tileData);
            }
