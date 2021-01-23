        public static void Dispose(this IEnumerable collection)
        {
            foreach (var obj in collection.OfType<IDisposable>())
            {
                obj.Dispose();
            }
        }
