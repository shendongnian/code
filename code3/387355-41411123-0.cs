    [Flags] 
    public enum SomeEnum
    {
        None       = 0,
        SomeValue  = 1,
        SomeValue2 = 1 << 1,
        SomeValue3 = 1 << 2,
        SomeValue4 = 1 << 3,
    }
    
    public static class SomeEnumUtility {
        
        private static readonly SomeEnum[] _someEnumValues = (SomeEnum[])Enum.GetValues( typeof(SomeEnum) );
        public static readonly SomeEnum SomeEnum_All = GetSomeEnumAll();
        
        // Unfortunately C# does not support "enum generics" otherwise this could be a generic method for any Enum type
        private static SomeEnum GetSomeEnumAll() {
            
            SomeEnum value = SomeEnum.None; // or `(SomeEnum)0;` if None is undefined.
            foreach(SomeEnum option in _someEnumValues) {
                value |= option;
            }
            return value;
        }
    }
