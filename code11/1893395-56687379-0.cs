    public class ExceptionWithCode : Exception
    {
        public ExceptionWithCode(string code, string message) : base(message)
        {
            this.Code = code;
        }
        public string Code { get; }
    }
