    public static class MyExtensions
    {
        public static Guid? ToGuid(this string arg)
        {
            Guid? result = null;
            if(Guid.TryParse(arg, out Guid guid))
                result = guid;
            return result;
        }
    }
