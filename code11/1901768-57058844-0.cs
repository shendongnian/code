    public abstract class ResponseCode
    {
        public abstract int NumericCode { get; }
        private ResponseCode() { }
        public sealed class Success : ResponseCode
        {
            public override int NumericCode => 200;
        }
        public sealed class Error : ResponseCode
        {
            public override int NumericCode => 500;
        }
    }
