    static class MyEnumUtils {
        public static bool Value(this MyEnum value) {
            switch(value) {
                case MyEnum.MyTrue: return true;
                case MyEnum.MyFalse: return false;
                default: throw new ArgumentOutOfRangeException("value");
                     // ^^^ yes, that is possible
            }
        }
    }
