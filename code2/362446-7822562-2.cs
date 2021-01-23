    class MyComparer : IEqualityComparer<CustomObject>
    {
        public bool Equals(CustomObject x, CustomObject y)
        {
            return x.City.Equals(y.City);
        }
        public int GetHashCode(CustomObject x)
        {
            return x.City.GetHashCode()
        }
    }
