    public class Token
    {
        public Token(string value)
        {
            Value = value;
        }
    
        public string Value { get; private set; }
        public static implicit operator string(Token token)
        {
            return token == null ? null : token.Value;
        }
        public bool Equals(string value)
        {
            return String.Equals(Value, value);
        }
        public override bool Equals(object obj)
        {
            var other = obj as Token;
            if (other == null)
            {
                return false;
            }
            return Equals(other.Value);
        }
        public override int GetHashCode()
        {
            return Value.GetHashCode();
        }
        public override string ToString()
        {
            return Value;
        }
    }
    
    public static class Tokens
    {
        public static readonly Token Foo = new Token("Foo");
    }
    class Program
    {
        static void Main(string[] args)
        {
            // You can use it as if they were string constants.
            string token = Tokens.Foo;
            bool areEquals = String.Equals(token, Tokens.Foo);
        }
    }
