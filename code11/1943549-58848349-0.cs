    class Position
    {
        public int X { get; set; }
        public int Y { get; set; }
        public override bool Equals(object other)
        {
            if (other == null || !(other is Position))
            {
                return false;
            }
            var otherPosition = (Position)other;
            return otherPosition.X == this.X && otherPosition.Y == this.Y;
        }
        public override int GetHashCode()
        {
            return this.X * 31 + this.Y;
        }
    }
