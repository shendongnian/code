    class Cube
        {
            List<Tile> Tiles = new List<Tile>(){
                new Tile(Color.blue, -1,1,2),
                new Tile(Color.blue, 0,1,0),
                new Tile(Color.blue, 1,1,2),
                new Tile(Color.blue, -1,0,2),
                new Tile(Color.blue, 0,0,2),
                new Tile(Color.blue, 0,1,2),
                new Tile(Color.blue, -1,-1,2),
                new Tile(Color.blue, 0,-1,2),
                new Tile(Color.blue, 1,-1,2),
                …
            };
    
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
            void rotateTopLayerAboutX()
            {
                foreach(var t in TopLayer)
                {
                }
            }
        }
    
        class Tile
        {
            public Tile (Color c, int x, int y, int z)
            {
                Color  = c;
                Position = new Point3D(x,y,z);
            }
    
            Color Color { get; private set; } // enum Color {...}
    
            Point3D Position { get; set; }
        }
