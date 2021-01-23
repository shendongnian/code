    public static class ListExtensions {
        private readonly static int seed = 17;
        private readonly static int multiplier = 23;
        public static int GetHashCodeByElements<T>(this List<T> list) {
            int hashCode = seed;
            for(int index = 0; index < list.Count; list++) {
                hashCode = hashCode * multiplier + list[index].GetHashCode();
            }
            return hashCode;
        }
    }
