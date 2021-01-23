    class TileSettings
    {
        public readonly TileType TYPE;
        public static readonly TileSettings TileOne = new TileSettings(TileType.TileOne);
        public static readonly TileSettings TileTwo = new TileSettings(TileType.TileTwo);
        public TileSettings(TileType type)
        {
             TYPE = type;
        }
    }
