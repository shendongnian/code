    public static class Utils {
        public static bool IsAny<T>(this IEnumerable<T> data) {
            return data != null && data.Any();
        }
    }
