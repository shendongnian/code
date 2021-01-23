    public sealed class EnumWrapper
    {
        private int _value;
        private string _name;
    
        private EnumWrapper(int value, string name)
        {
            _value = value;
            _name = name;
        }
        public override string ToString()
        {
            return _name;
        }
    
        // Allow visibility to only the items you want to
        public static EnumWrapper Client = new EnumWrapper(0, "Client");
        public static EnumWrapper AnotherClient= new EnumWrapper(1, "AnotherClient");
    
        // The internal keyword makes it only visible internally
        internal static readonly EnumWrapper SecretClient= new EnumWrapper(-1, "SecretClient");
    }
