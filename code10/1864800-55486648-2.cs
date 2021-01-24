    using System;
    
    public static class MyExtensions
    {
        /// <summary>
        ///     Magic method.
        /// </summary>
        /// <param name="source">
        ///     The source array.
        /// </param>
        /// <exception cref="ArgumentNullException">
        ///     <paramref name="source" /> is <c>null</c>.
        /// </exception>
        /// <returns>
        ///     Some magic value only you know about.
        /// </returns>
        public static int SomeMethod(this int[] source)
        {
            if (source == null)
                throw new ArgumentNullException(nameof(source));
    
            return 42;
        }
    }
