            IEnumerable<Tile> TopLayer
            {
                get
                {
                    return Tiles.Where(f => f.Position.Y == 2 || f.Position.Y == 1);
                }
            }
            IEnumerable<Tile> BottomLayer {…}
            Color getTileColor(int x,int y,int z)
            {
                return Tiles.Single(t => t.Position.X == x && t.Position.Y == y && t.Position.Z == z).Color;
            }
