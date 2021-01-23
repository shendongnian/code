    public class CustomComparer<TSource, TCompareType> : IEqualityComparer<TSource> where TSource : class 
    {
        private readonly Func<TSource, TCompareType> getComparisonObject;
        public CustomComparer(Func<TSource,TCompareType> getComparisonObject)
        {
            if (getComparisonObject == null) throw new ArgumentNullException("getComparisonObject");
            this.getComparisonObject = getComparisonObject;
        } 
        /// <summary>
        /// Determines whether the specified objects are equal.
        /// </summary>
        /// <returns>
        /// true if the specified objects are equal; otherwise, false.
        /// </returns>
        /// <param name="x">The first object of type <paramref name="T"/> to compare.
        ///                 </param><param name="y">The second object of type <paramref name="T"/> to compare.
        ///                 </param>
        public bool Equals(TSource x, TSource y)
        {
            if (x == null)
            {
                return (y == null);
            }
            else if (y == null)
            {
                return false;
            }
            return EqualityComparer<TCompareType>.Default.Equals(getComparisonObject(x), getComparisonObject(y));
        }
        /// <summary>
        /// Returns a hash code for the specified object.
        /// </summary>
        /// <returns>
        /// A hash code for the specified object.
        /// </returns>
        /// <param name="obj">The <see cref="T:System.Object"/> for which a hash code is to be returned.
        ///                 </param><exception cref="T:System.ArgumentNullException">The type of <paramref name="obj"/> is a reference type and <paramref name="obj"/> is null.
        ///                 </exception>
        public int GetHashCode(TSource obj)
        {
            return EqualityComparer<TCompareType>.Default.GetHashCode(getComparisonObject(obj));
        }
    }
