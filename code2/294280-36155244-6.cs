    using System;
    
    namespace MmbpTree
    {
        public static class Extensions
        {
            public static T[] Add<T>(this T[] array, T element)
            {
                var result = new T[array.Length + 1];
                Array.Copy(array, result, array.Length);
                result[array.Length] = element;
                return result;
            }
    
            public static unsafe byte*[] Add(this byte*[] array, byte* element)
            {
                var result = new byte*[array.Length + 1];
                Array.Copy(array, result, array.Length);
                result[array.Length] = element;
                return result;
            }
        }
    }
