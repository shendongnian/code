    public static class ThrowHelper
    {
        public static TException ThrowIfNull<TException>(object value)
            where TException : Exception, new()
        {
            if (value == null) //or other checks
            {
              throw new TException();
            }
        }
    }
