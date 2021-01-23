    public class CustomException : Exception
    {
        public string MyVar1 { get; private set; }
        public string MyVar2 { get; private set; }
        public Exception OriginalException { get; private set; }
    
        public CustomException(Exception original, string myVar1, string myVar2)
        {
            MyVar1 = myVar1;
            MyVar2 = myVar2;
            OriginalException = original;
        }
    }
