    public class RetrnClass
    {
        public int AmountOfFiles { get; set; }
        public int ErrorCode { get; set; }
        public String ErrorMessage { get; set; }
        public Exception ExceptionObject { get; set; }
        public bool IsValid { get { return ExceptionObject == null; } }
        public static implicit operator bool(RetrnClass cls) { return cls.IsValid; }
    }
