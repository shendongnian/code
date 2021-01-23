    public abstract class ValidationResultItem
    {
        private ResultType _resultType;
        protected ValidationResultItem(ResultType resultType, string message)
        {
            ResultType = resultType;
            Message = message;
        }
        public bool IsAcceptable { get; private set; }
        public string Message { get; private set; }
        public ResultType ResultType
        {
            get { return _resultType; }
            set { _resultType = value; IsAcceptable = (_resultType != ResultType.Error); }
        } 
    }
