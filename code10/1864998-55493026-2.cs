    public class Edge : IComparable
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
    
        public bool CompareTo(object other)
        {
            // your comparison here
        }
     }
