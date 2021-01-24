    public static class ArrayExtensions {
        public static void Print<T> (this IEnumerable<T> items) {
            foreach (var item in items) {
                Console.WriteLine (item);
            }
        }
    }
