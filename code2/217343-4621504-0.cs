    public class ComMessageException : Exception
    {
        public ComMessageException(string message)
            :base(message)
        {
            HResult = unchecked((int)0x80004005);
        }
    }
