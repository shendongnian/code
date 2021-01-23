    public static class Never
    {
        public static T Null<T>(T value)
            where T : class
        {
            if (value == null) throw new ArgumentNullException();
            return value;
        }
    }
    myClass.AProperty = Never.Null(somePotentiallyNullValue);
