    class GameTile 
    {
        private Vector2D _vec;
        //These integers should be sized to fit your needs
        //int8 = up to 256 tilesets
        //int16 = up to 65536 tiles in a set
        private int8 _tileSet;
        private int16 _tileIndex;
        
        //This is the tiles position in the world
        public Vector2D Position { get { return _vec; } }
        //This is the index of the tileset in the array of all tilesets
        public int8 CurrentTileset { get { return _tileSet; } }
        //This is the flattened index (row * width + column) 
        //of the tile in the tileset
        public int16 CurrentTile { get { return _tileIndex; } }        
    }
