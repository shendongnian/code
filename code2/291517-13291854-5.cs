    public class MetricDistance
    {
        public static readonly MetricDistance Milimeter  = new MetricDistance(0.001);
        public static readonly MetricDistance Centimeter = new MetricDistance(0.01);
        public static readonly MetricDistance Decimeter  = new MetricDistance(0.1);
        public static readonly MetricDistance Meter      = new MetricDistance(1.0);
        public static readonly MetricDistance Decameter  = new MetricDistance(10.0);
        public static readonly MetricDistance Hectometer = new MetricDistance(100.0);
        public static readonly MetricDistance Kilometer  = new MetricDistance(1000.0);
        private double _meters;
        
        public MetricDistance(double meters)
        {
            _meters = meters;
        }
        public double ToMilimeters()
        {
            return _meters / Milimeter._meters;
        }
        public double ToCentimeters()
        {
            return _meters / Centimeter._meters;
        }
        public double ToDecimeters()
        {
            return _meters / Decimeter._meters;
        }
        public double ToMeters()
        {
            return _meters;
        }
        public double ToDecameters()
        {
            return _meters / Decameter._meters;
        }
        public double ToHectometers()
        {
            return _meters / Hectometer._meters;
        }
        public double ToKilometers()
        {
            return _meters / Kilometer._meters;
        }
        public ImperialDistance ToImperialDistance()
        {
            return new ImperialDistance(_meters * 39.3701);
        }
        public override int GetHashCode()
        {
            return _meters.GetHashCode();
        }
        public override bool Equals(object obj)
        {
            var o = obj as MetricDistance;
            if (o == null) return false;
            return _meters.Equals(o._meters);
        }
        
        public static bool operator ==(MetricDistance a, MetricDistance b)
        {
            // If both are null, or both are same instance, return true
            if (ReferenceEquals(a, b)) return true;
            // if either one or the other are null, return false
            if (ReferenceEquals(a, null) || ReferenceEquals(b, null)) return false;
            return a._meters == b._meters;
        }
        public static bool operator !=(MetricDistance a, MetricDistance b)
        {
            return !(a == b);
        }
        public static MetricDistance operator +(MetricDistance a, MetricDistance b)
        {
            if (a == null) throw new ArgumentNullException("a");
            if (b == null) throw new ArgumentNullException("b");
            return new MetricDistance(a._meters + b._meters);
        }
        public static MetricDistance operator -(MetricDistance a, MetricDistance b)
        {
            if (a == null) throw new ArgumentNullException("a");
            if (b == null) throw new ArgumentNullException("b");
            return new MetricDistance(a._meters - b._meters);
        }
        public static MetricDistance operator *(MetricDistance a, MetricDistance b)
        {
            if (a == null) throw new ArgumentNullException("a");
            if (b == null) throw new ArgumentNullException("b");
            return new MetricDistance(a._meters * b._meters);
        }
        public static MetricDistance operator /(MetricDistance a, MetricDistance b)
        {
            if (a == null) throw new ArgumentNullException("a");
            if (b == null) throw new ArgumentNullException("b");
            return new MetricDistance(a._meters / b._meters);
        }
    }
