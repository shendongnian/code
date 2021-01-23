    class TileSettings
    {
        public readonly TileType TYPE;
        public static TileSettings TileOne = new TileSettings(TileType.TileOne);
        public static TileSettings TileTwo = new TileSettings(TileType.TileTwo);
        public TileSettings(TileType type)
        {
             TYPE = type;
        }
    }
