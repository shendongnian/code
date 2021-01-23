    public class SendResult : ActionResult<string>
    { ... }
    public class ActionResult<T>
    {
        public bool Success { get; private set; }
        public T Value { get; private set; }
        public ActionResult<T>(bool success, T value)
        {
            Success = success;
            Value = value;
        }
    }
