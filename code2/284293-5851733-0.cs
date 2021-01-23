    public abstract MyExceptionBase : Exception
    {
        protected MyExceptionBase(string message, string helpLink) : 
            base(message)
        {
            HelpLink = helpLink;
        }
    }
    public MyException : MyExceptionBase
    {
        public MyException(string message) : 
            base(message, "http://www.google.com")
        { }
    }
