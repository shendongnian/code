    public static class ExceptionExtensions
    {
        public static Exception GetInnermostException(this Exception e)
        {
            if (e == null)
            {
                throw new ArgumentNullException("e");
            }
            while (e.InnerException != null)
            {
                e = e.InnerException;
            }
            return e;
        }
    }
