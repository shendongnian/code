    public class EndPoint
    {
        public EndPoint(int index, List<PointF> points)
        {
            this.Position = points[index];
            if (index < points.Count - 1)
                this.Next = points[index + 1];
        }
        public PointF Position { get; private set; }
        public PointF Next { get; private set; }
        public double GetDistanceToNext()
        {
            if(this.Next == PointF.Empty)
                return 0;
            var xDiff = this.Position.X - Next.X;
            var yDiff = this.Position.Y - Next.Y;
            return Math.Abs(Math.Sqrt((xDiff*xDiff) + (yDiff*yDiff)));
        }
    }
