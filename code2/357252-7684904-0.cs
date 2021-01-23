    public class StringEnum
    {
        #region Enum Values
    
        public static readonly StringEnum ValueOne = new StringEnum("Value One");
        public static readonly StringEnum ValueTwo = new StringEnum("Value Two");
    
        #endregion
    
        #region Enum Functionality
    
        public readonly string Value;
    
        private StringEnum(string value)
        {
            Value = value;
        }
    
        public override string ToString()
        {
            return value;
        }
    
        #endregion
    }
