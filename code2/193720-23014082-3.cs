        public static class IDisposeableEnumerableExtensions
        {
            /// <summary>
            /// Wraps the given IEnumarable into a DisposeableEnumerable which ensures that all the disposeables are disposed correctly
            /// </summary>
            /// <typeparam name="T">The IDisposeable type</typeparam>
            /// <param name="enumerable">The enumerable to ensure disposing the elements of</param>
            /// <returns></returns>
            public static DisposeableEnumerable<T> AsDisposeableEnumerable<T>(this IEnumerable<T> enumerable) where T : System.IDisposable
            {
                return new DisposeableEnumerable<T>(enumerable);
            }
        }
