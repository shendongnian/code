    static class Extensions
    {
            public static String ConvertNullValue(this String value)
            {
                return value ?? "00";
            }
    }
