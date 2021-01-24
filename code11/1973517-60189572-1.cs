    public class AllPropertiesEqualityComparer<T> : IEqualityComparer<T>
    {
        private PropertyInfo[] publicInstanceProperties;
    
        public AllPropertiesEqualityComparer()
        {
            publicInstanceProperties = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance);
        }
    
        public bool Equals(T x, T y)
        {
            foreach (PropertyInfo property in publicInstanceProperties)
            {
                if (property.CanRead && property.GetIndexParameters().Length == 0 && !property.GetValue(x).Equals(property.GetValue(y)))
                {
                    return false;
                }
            }
            return true;
        }
    
        public int GetHashCode(T obj)
        {
            long stackedHashCodes = 0;
            foreach (PropertyInfo property in publicInstanceProperties)
            {
                stackedHashCodes += property.GetValue(obj).GetHashCode();
            }
            return (int)(stackedHashCodes % int.MaxValue);
        }
    }
