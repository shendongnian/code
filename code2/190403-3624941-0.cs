        private string GetFirstEnumLetter(Tile tile)
        {
            if (tile.ToString().Length > 0)
            {
                return tile.ToString().Substring(0, 1);
            }
            return string.Empty;
        }
