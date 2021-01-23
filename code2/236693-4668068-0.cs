    using System;
    
    namespace Utils.Extensions
    {
        public static class EnumerableExtensions
        {
            public static bool Between<T extends IComparable<T>>(this T item, T min, T max)
            {
                return item.CompareTo(min) >= 0 && item.CompareTo(max) <= 0;
            }
        }
    }
