    using System.Reflection;
    public static class HashCode
    {
        public static ulong CreateHashCode(this object obj)
        {
            ulong hash = 0;
            Type objType = obj.GetType();
            if (objType.IsValueType || obj is string)
            {
                unchecked
                {
                    hash = (uint)obj.GetHashCode() * 397;
                }
                return hash;
            }
            unchecked
            {
                foreach (PropertyInfo property in obj.GetType().GetProperties())
                {
                    object value = property.GetValue(obj, null);
                    hash ^= value.CreateHashCode();
                }
            }
            return hash;
        }
    }
