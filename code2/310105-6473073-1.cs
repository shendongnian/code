    public static class StringHelper {
        public static string ValueOrWhatever(this string value, string defaultValue) {
            return string.IsNullOrEmpty(value) ? defaultValue : value;
        }
    }
    myVal = object1.object2.something(a,b).DataColumn.ToString().ValueOrWhatever("-");
