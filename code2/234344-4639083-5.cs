    class GenericPropertyComparer<T> : IComparer<T>
    {
        public GenericPropertyComparer(string propertyName)
        {
            var property = typeof(T).GetProperty(propertyName, BindingFlags.Instance | BindingFlags.Public);
    
            if (property == null)
                throw new ArgumentException("property doesn't specify a valid property");
            if (property.CanRead == false)
                throw new ArgumentException("property specify a write-only property");
            if (property.PropertyType.GetInterface("IComparable") == null)
                throw new ArgumentException("property type doesn't IComparable");
    
            mSortingProperty = property;
        }
    
        public int Compare(T x, T y)
        {
            IComparable propX = (IComparable)mSortingProperty.GetValue(x, null);
            IComparable propY = (IComparable)mSortingProperty.GetValue(y, null);
    
            return (propX.CompareTo(propY));
        }
    
        private PropertyInfo mSortingProperty = null;
    }
