        } // class cube
    
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
