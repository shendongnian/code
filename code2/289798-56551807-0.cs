    static class EnumExtensions {
        public static T GetEnum<T>(this string itemName) {
            return (T) Enum.Parse(typeof(T), itemName, true);
        }
    }
