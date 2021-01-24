    public struct Line
    {
        public Line(Point start, Point end)
        {
            Start = start;
            End = end;
        }
        public Point Start { get; }
        public Point End { get; }
        public override string ToString()
        {
            return String.Format($"({Start.X}, {Start.Y}) - ({End.X}, {End.Y})");
        }
    }
