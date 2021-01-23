    [Serializable()]
    public class OwnException : System.Exception
    {
        public readonly MaybeDateTime;
        ...
        public OwnException (string message, System.Exception inner) :  base(message, inner) { maybe = null; }
        public OwnException (string message, System.Exception inner, DateTime maybe) :  base(message, inner) { MaybeDateTime = maybe; }
    }
