    public struct FinishPosition {
        public readonly int Position;
        public FinishPosition(int position) {
            this.Position = position;
        }
        public static implicit operator FinishPosition(int position) {
            return new FinishPosition(position);
        }
    }
    // ...
    Dictionary<FinishPosition, Driver> dict = new Dictionary<FinishPosition, Driver>();
    Driver bob = new Driver();
    // The following two lines are effectively equivalent
    dict[new FinishPosition(7)] = bob;
    dict[7] = bob;
    // So are these two
    bob = dict[7];
    bob = dict[new FinishPosition(7)]
