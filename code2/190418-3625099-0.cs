        enum Tile { Empty, White, Black };
        private string TileToString(Tile t)
        {
            switch (t)
            {
                case Tile.Empty:
                    return ".";
                case Tile.White:
                    return "W";
                case Tile.Black:
                    return "B";
                default:
                    return ".";
            }
        }
