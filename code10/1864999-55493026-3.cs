    public class Edge : IComparable<Edge>
    {
        public long u;
        public long v;
        public double weight;
        public Edge(long a, long b, double c)
        {
            u = a;
            v = b;
            weight = c;
        }
    
        public int CompareTo(Edge other)
        {
            // your comparison here
        }
     }
