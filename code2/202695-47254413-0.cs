    public class Name
    {
        public string Value;
        public static implicit operator string(Name name) { return name.Value; }
        public static implicit operator Name(string name) { return new Name {Value = name}; }
    }
