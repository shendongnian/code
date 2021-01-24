    public class CarbonCopyToken
    {
        public JToken Original { get; set; }
        public JToken CarbonCopy { get; set; }
    }
    /// <summary>
    /// A generic object comparerer that would only use object's reference, 
    /// ignoring any <see cref="IEquatable{T}"/> or <see cref="object.Equals(object)"/>  overrides.
    /// </summary>
    public class ObjectReferenceEqualityComparer<T> : IEqualityComparer<T> where T : class
    {
        // Adapted from this answer https://stackoverflow.com/a/1890230
        // to https://stackoverflow.com/questions/1890058/iequalitycomparert-that-uses-referenceequals
        // By https://stackoverflow.com/users/177275/yurik
        private static readonly IEqualityComparer<T> _defaultComparer;
    
        static ObjectReferenceEqualityComparer() { _defaultComparer = new ObjectReferenceEqualityComparer<T>(); }
    
        public static IEqualityComparer<T> Default { get { return _defaultComparer; } }
    
        #region IEqualityComparer<T> Members
    
        public bool Equals(T x, T y)
        {
            return ReferenceEquals(x, y);
        }
    
        public int GetHashCode(T obj)
        {
            return System.Runtime.CompilerServices.RuntimeHelpers.GetHashCode(obj);
        }
    
        #endregion
    }
