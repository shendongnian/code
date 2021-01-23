    using System.Collections.Generic;
    using System.Linq;
    
    namespace Common.Helpers
    {
        /// <summary>
        /// This class with only one method helps to resolve
        /// name conflict between .Net 4.7.2 and MoreLinq libraries.
        ///
        /// .Net 4.7.2 introduced a new extension method named '.ToHashSet()'.
        /// But MoreLinq already has the same method.
        ///
        /// After migrating our solution from .Net 4.7.1 to 4.7.2
        /// C# compiler shows "The call is ambiguous" error.
        ///
        /// We cannot have both "using System.Linq;" and "using MoreLinq;" in the same C# file that
        /// uses '.ToHashSet()'.
        ///
        /// The solution is to have method with different name in a file like this.
        /// </summary>
        public static class ToHashsetHelpers
        {
            /// <summary>
            /// The name of this method is ToHashset (not ToHashSet)
            /// </summary>
            public static HashSet<TSource> ToHashset<TSource>(this IEnumerable<TSource> source)
            {
                // Calling System.Linq.Enumerable.ToHashSet()
                return source.ToHashSet();
            }
        }
    }
