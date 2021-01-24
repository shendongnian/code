    class PropertyNameComparer : IEqualityComparer<Property>
    {
        public bool Equals(Property x, Property y) => x.Name.Equals(y.Name);
        public int GetHashCode(Property p) => p.Name.GetHashCode();
    }
