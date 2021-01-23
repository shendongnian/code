    public static class ConvertUtility
    {
        public static T Convert<T>(object source) where T : IConvertible
        {
            return (T)System.Convert.ChangeType(source, typeof(T));
        }              
    }
