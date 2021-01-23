        public static string Coalesce(string defaultValue, params string[] values) {
            if (string.IsNullOrEmpty(defaultValue))
                throw new ArgumentException("defaultValue");
            foreach (var value in values) {
                if (!string.IsNullOrEmpty(value))
                    return value;
            }
            return defaultValue;
        }
