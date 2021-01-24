    class ThatType
    {
        public ThatType() { ... }
        public ThatType(ThisType input) { ... }
        ...
    
        public static implicit operator ThatType(ThisType t) => new ThatType(t);
    }
