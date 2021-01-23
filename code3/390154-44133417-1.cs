    internal static class NullableChecker
    {
        public static bool AnyIsNull<T>(T? value) where T : struct
        {
            return false == value.HasValue;
        }
        public static bool AnyIsNull<T1, T2>(T1? value1, T2? value2) where T1 : struct where T2 : struct
        {
            return false == value1.HasValue || false == value2.HasValue;
        }
        public static bool AnyIsNull<T1, T2, T3>(T1? value1, T2? value2, T3? value3) where T1 : struct where T2 : struct where T3 : struct
        {
            return false == value1.HasValue || false == value2.HasValue || false == value3.HasValue;
        }
        public static bool AnyIsNull<T1, T2, T3, T4>(T1? value1, T2? value2, T3? value3, T4? value4) where T1 : struct where T2 : struct where T3 : struct where T4 : struct
        {
            return false == value1.HasValue || false == value2.HasValue || false == value3.HasValue || false == value4.HasValue;
        }
    }
