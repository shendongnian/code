    public static class MyHelper {
        public static void ForEach(this IEnumerable<int[]> rowsAndColumns, Action<int> action) {
            foreach (int[] columns in rowsAndColumns) {
                 foreach (int element in columns) {
                     action(element);
                 }
            }
        }
    }
