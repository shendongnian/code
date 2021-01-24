    class BlockDescriptor 
    {
        public Tile Tile { get; }
        public int Hardness { get;}
        public string DisplayName { get; }
        public bool HasGravity { get; }
        public BlockDescriptor(Tile tile, int hardness, string name, bool gravity)
        {
            Tile = tile;
            Hardness = hardness;
            DisplayName = name;
            HasGravity = gravity;
        }
    }
