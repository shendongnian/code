    public static class StringHelper {
        public static string ValueOrDash(this string value) {
            return string.IsNullOrEmpty(value) ? "-" : value;
        }
    }
