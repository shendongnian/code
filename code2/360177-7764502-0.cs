    public class MyEnum
    {
        #region Enum Values
    
        public static readonly StringEnum ValueOne = new MyEnum(0);
        public static readonly StringEnum ValueTwo = new MyEnum(1);
    
        #endregion
    
        #region Enum Functionality
    
        private readonly int Value;
    
        private MyEnum(int value)
        {
            Value = value;
        }
    
        public override string ToString()
        {
            return Value.ToString();
        }
    
        #endregion
    }
