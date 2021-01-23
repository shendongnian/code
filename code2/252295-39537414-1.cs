    public static class Utils {
        public static bool IsNullOrEmpty<T>(this IEnumerable<T> list) {
            return !(list?.Any()).GetValueOrDefault();
        }
    }
