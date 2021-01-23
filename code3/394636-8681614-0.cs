    using System;
    using System.Collections.Generic;
    
    namespace Utility
    {
        public static class IEnumerableUtility
        {
            public static void ForEach<T>(this IEnumerable<T> list, Action<T> action)
            {
                foreach (var item in list)
                    action(item);
            }
        }
    }
