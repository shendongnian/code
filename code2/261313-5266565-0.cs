    // returns null if there is no intersection
    Intersection? Intersect(Ray ray) { ... }
    struct Intersection 
    {
        public double Distance { get; private set; }
        public Vector3 Normal { get; private set; }
        public Intersection(double distance, Vector3 normal) : this()
        {
            this.Normal = normal;
            this.Distance = distance;
        }
    } 
