    public class Triangle
    {
        public PointF Point1 { get; }
        public PointF Point2 { get; }
        public PointF Point3 { get; }
        public IEnumerable<PointF> Points => new List<PointF> { Point1, Point2, Point3 };
        public Triangle(PointF point1, PointF point2, PointF point3)
        {
            this.Point1 = point1;
            this.Point2 = point2;
            this.Point3 = point3;
        }
        public Triangle(float x1, float y1, float x2, float y2, float x3, float y3)
            : this(new PointF(x1, y1), new PointF(x2, y2), new PointF(x3, y3)) { }
        public bool IsAdjacentTo(Triangle other) => this.Points.Intersect(other.Points).Count() > 1;
    }
    public class TriangleRegistryList
    {
        public IList<Triangle> Triangles { get; }
        public Dictionary<Triangle, List<Triangle>> AdjacentMap { get; }
        public TriangleRegistryList(IEnumerable<Triangle> triangles)
        {
            this.Triangles = new List<Triangle>(triangles);
            this.AdjacentMap = GetAdjacentMap();
        }
        private Dictionary<Triangle, List<Triangle>> GetAdjacentMap()
        {
            return Triangles.ToDictionary(t => t, a => Triangles.Where(b => b.IsAdjacentTo(a)).ToList());
        }
    }
