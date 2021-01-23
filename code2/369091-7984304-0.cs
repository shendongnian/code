    class IntPoint {
        public int X { get; set; }
        public int Y { get; set; }
    
        public IntPoint(int X, int Y) {
            this.X = X;
            this.Y = Y;
        }
        public override bool Equals(object obj)
        {
            if (obj is IntPoint) return Equals(obj as IntPoint);
            return base.Equals(obj);
        }
    
        public bool Equals(IntPoint anotherPoint) {
            return ((anotherPoint.X == X) && (anotherPoint.Y == Y));
        }
    }
