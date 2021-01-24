    public class MyError
    {
        public MyError(string message) => Message = message;
        public string Message { get; }
    }
    public class Hopefully<T>
    {
        public Hopefully(T value) => SomeTValue = value;
        public Hopefully(MyError error) => Error = error;
        public static implicit operator Hopefully<T>(T value) => new Hopefully<T>(value);
        public static implicit operator Hopefully<T>(MyError error) => new Hopefully<T>(error);
        public MyError Error { get; }
        public T SomeTValue { get; }
        public Hopefully<U> Chain<U>(Func<T, U> convert)
        {
            if (Error != null) {
                return Error;
            }
            return convert(SomeTValue);
        }
        public override string ToString() =>
            Error != null ? $"Error: {Error.Message}" : SomeTValue.ToString();
    }
