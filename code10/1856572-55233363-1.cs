    public class EncryptedString
    {
        private readonly string _value;
        public EncryptedString(string value)
        {
            _value = value;
        }
        public static implicit operator string(EncryptedString s)
        {
            return s._value;
        }
        public static implicit operator EncryptedString(string value)
        {
            if (value == null)
                return null;
            return new EncryptedString(value);
        }
    }
