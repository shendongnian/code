    using System;
    using System.Reflection;
    // ... You will want this in your own namespace not mine. ;-)
    ///<summary>
    /// Copies properties with the same name and type from one object to another.
    ///</summary>
    ///<typeparam name="TFirst">The object type to copy from.</typeparam>
    ///<typeparam name="TSecond">The object type to copy to.</typeparam>
    public class PropertyCopier<TFirst, TSecond> 
        where TFirst : class
        where TSecond : class
    {
        private readonly TFirst _first;
        private readonly TSecond _second;
        ///<summary>
        /// Creates an instance of the PropertyCopier.
        ///</summary>
        ///<param name="first">The object to copy properties from.</param>
        ///<param name="second">The object to copy properties to.</param>
        ///<exception cref="ArgumentNullException">An <see cref="ArgumentNullException"/> will be thrown if
        /// the source or destination objects are null.</exception>
        public PropertyCopier(TFirst first, TSecond second)
        {
            if ( first == null )
            {
                throw new ArgumentNullException("first");
            }
            if (second == null)
            {
                throw new ArgumentNullException("second");
            }
            _first = first;
            _second = second;
        }
        ///<summary>
        /// Performs the copy operation.
        ///</summary>
        public void Copy()
        {
            Copy(p => true);
        }
        ///<summary>
        /// Performs the copy operation, omitting any items for which the predicate evaluates to false.
        ///</summary>
        ///<param name="predicate">A predicate based on the <see cref="PropertyInfo"/> used to determine if the property should be copied.</param>
        ///<exception cref="ArgumentException">An <see cref="ArgumentException"/> may be thrown if the copy cannot be performed.
        /// This may happen if, for example, there is a property with the same name but a different type.</exception>
        public void Copy(Predicate<PropertyInfo> predicate)
        {
            foreach (PropertyInfo info in typeof(TFirst).GetProperties())
            {
                PropertyInfo infoInDestination = null;
                try
                {
                    infoInDestination = typeof(TSecond).GetProperty(info.Name, info.PropertyType);
                }
                catch (AmbiguousMatchException)
                {
                }
                try
                {
                    if (infoInDestination != null && infoInDestination.CanWrite && predicate(infoInDestination))
                    {
                        infoInDestination.SetValue(_second, info.GetValue(_first, null), null);
                    }
                }
                catch (Exception e)
                {
                    throw new ArgumentException(String.Format("Unable to copy property called {0}", info.Name), e);
                }
            }
        }
    }
