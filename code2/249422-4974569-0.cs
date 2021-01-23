    private struct MultiPartKey : IEquatable<MultiPartKey>
    {
        private readonly int itemId;
        private readonly int regionId;
        public int ItemId { get { return itemId; } }
        public int RegionId { get { return regionId; } }
        public MultiPartKey(int itemId, int regionId)
        {
            this.itemId = itemId;
            this.regionId = regionId;
        }
        public override int GetHashCode()
        {
            int hash = 17;
            hash = hash * 31 + itemId;
            hash = hash * 31 + regionId;
            return hash;
        }
        public override bool Equals(object other)
        {
            return other is MultiPartKey ? Equals((MultiPartKey)other) : false;
        }
        public bool Equals(MultiPartKey other)
        {
            return itemId == other.itemId &&
                   regionId == other.regionId;
        }
    }
