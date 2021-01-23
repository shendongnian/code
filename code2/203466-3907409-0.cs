    public static bool EqualsAny<T>(IEquatable<T> value, params T[] possibleMatches) {
        foreach (T t in possibleMatches) {
            if (value.Equals(t))
                return true;
        }
        return false;
    }
    public static bool EqualsAny<T>(IEquatable<T> value, IEnumerable<T> possibleMatches) {
        foreach (T t in possibleMatches) {
            if (value.Equals(t))
                return true;
        }
        return false;
    }
