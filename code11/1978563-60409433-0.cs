    interface IPoint
    {
        public int NumDims { get; }
        public int Accept(IVisitor visitor);
    }
    public struct Point2 : IPoint
    {
        public int NumDims => 2;
        public int Accept(IVisitor visitor)
        {
            return visitor.Visit(this);
        }
    }
    public struct Point3 : IPoint
    {
        public int NumDims => 3;
        public int Accept(IVisitor visitor)
        {
            return visitor.Visit(this);
        }
    }
    public class Visitor : IVisitor
    {
        public int Visit(Point2 toVisit)
        {
            return toVisit.NumDims;
        }
        public int Visit(Point3 toVisit)
        {
            return toVisit.NumDims;
        }
    }
    public interface IVisitor<T>
    {
        int Visit(T toVisit);
    }
    public interface IVisitor : IVisitor<Point2>, IVisitor<Point3> { }
    class Program
    {
        static int GetDim<T>(T point) where T : IPoint => 0;
        static int GetDim(Point2 point) => point.NumDims;
        static int GetDim(Point3 point) => point.NumDims;
        static int GenericAlgorithm<T>(T point) where T : IPoint => point.Accept(new Visitor());
        static void Main(string[] args)
        {
            Point2 p2;
            Point3 p3;
            int d1 = GenericAlgorithm(p2);
            int d2 = GenericAlgorithm(p3);
            Console.WriteLine("{0:d}", d1);        // returns 2
            Console.WriteLine("{0:d}", d2);        // returns 3
        }
    }
