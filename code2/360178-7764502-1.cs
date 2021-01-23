    public class MyEnum
    {
        #region Enum Values
        // Pre defined values.    
        public static readonly MyEnum ValueOne = new MyEnum(0);
        public static readonly MyEnum ValueTwo = new MyEnum(1);
        // All values in existence.
        private static readonly Dictionary<int, MyEnum> existingEnums = new Dictionary<int, MyEnum>{{ValueOne.Value, ValueOne}, {ValueTwo.Value, ValueTwo}};
    
        #endregion
    
        #region Enum Functionality
    
        private readonly int Value;
    
        private MyEnum(int value)
        {
            Value = value;
        }
        public static MyEnum GetEnum(int value)
        {
            // You will probably want to make this thread-safe.
            if (!existingEnums.ContainsKey(value)) existingEnums[value] = new MyEnum(value);
            return existingEnums[value];
        }
    
        public override string ToString()
        {
            return Value.ToString();
        }
    
        #endregion
    }
