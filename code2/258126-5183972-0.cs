    class ObjectComparer : IEqualityComparer<object>
    {
        public bool Equals(object x, object y)
        {
            if (x == null || y == null)
            {
                return false;
            }
    
            return x.GetType == typeof(object) && y.GetType() == typeof(object);
        }
        public int GetHashCode(object obj)
        {
            if (obj == null)
            {
                return 0;
            }
            if (obj.GetType() == typeof(object))
            {
                return 1; // I don't know, whatever.
            }
            return obj.GetHashCode();
        }
    }
