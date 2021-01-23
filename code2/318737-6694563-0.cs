    class Compare : IEqualityComparer<Class_reglement>
    {
        public bool Equals(Class_reglement x, Class_reglement y)
        {
            return x.Numf == y.Numf;
        }
        public int GetHashCode(Class_reglement codeh)
        {
            return codeh.Numf.GetHashCode();
        }
    }
