    sealed public class Name
    {
        private readonly string _value;
        private Name(string value) { _value = value; }
        public static implicit operator string(Name name) { return name._value; }
        public static implicit operator Name(string value) { return new Name(value); }
    }
