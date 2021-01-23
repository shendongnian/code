    public static class Extensions
        {
            public static IEnumerable<T> Distinct<T>(this IEnumerable<T> source, Func<T, T, bool> comparer)
            {           
                return source.Distinct(new DelegateComparer<T>(comparer));
            }
         
            public static IEnumerable<T> Distinct<T>(this IEnumerable<T> source, Func<T, T, bool> comparer, Func<T,int> hashMethod)
            {
                return source.Distinct(new DelegateComparer<T>(comparer,hashMethod));
            }
        }
         
        public class DelegateComparer<T> : IEqualityComparer<T>
        {
            private Func<T, T, bool> _equals;
            private Func<T,int> _getHashCode;
         
            public DelegateComparer(Func<T, T, bool> equals)
            {
                this._equals = equals;
            }
         
            public DelegateComparer(Func<T, T, bool> equals, Func<T,int> getHashCode)
            {
                this._equals = equals;
                this._getHashCode = getHashCode;
            }
         
            public bool Equals(T a, T b)
            {
                return _equals(a, b);
            }
         
            public int GetHashCode(T a)
            {
                if (_getHashCode != null)       
                    return _getHashCode(a);       
                else
                    return a.GetHashCode();
            }
        }
