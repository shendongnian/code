    public static class MyLogHelper
    {
        public static ILog GetLogger()
        {
            return LogHelper.GetLogger("MyHardcodedValue");
        }
    }
