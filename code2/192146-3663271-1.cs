    struct PointD : IEquatable<PointD>
    {
        public int X;
        public int Y;
        public int Z;
    
        public bool Equals(PointD other)
        {
            return (this.X == other.X) &&
                    (this.Y == other.Y) &&
                    (this.Z == other.Z);
        }
    }
