    class Map
    {
        public int Height { get; set; }
        public int Width { get; set; }
        public string Name { get; set; }
        public Tile[] Tiles { get; set; }
    }
    class Tile
    {
        public byte Terrain { get; set; }
        public byte Elevation { get; set; }
        public byte Illumination { get; set; }
        public int ActorID { get; set; }
    }
