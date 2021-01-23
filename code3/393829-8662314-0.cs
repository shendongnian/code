    public class Maybe<T>
    {
        public Exception Exception { get; protected set; }
        T _Value;
        public T Value {
            get {
                if (Exception != null) {
                    throw Exception;
                }
                return _Value;
            }
            protected set { _Value = value; }
        }
        public static Maybe<T> AsError(Exception ex)
        {
            return new Maybe<T>() {Value = default(T), Exception = ex};
        }
        public static Maybe<T> AsValue(T value)
        {
            return new Maybe<T>() {Value = value};
        }
    }
