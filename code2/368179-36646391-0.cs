    public class Token
    {
        public Token(string value)
        {
            Value = value;
        }
    
        public string Value { get; private set; }
        public override string ToString()
        {
            return Value;
        }
        public static implicit operator string(Token token)
        {
            return token.Value;
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
