    public static class DynamicCast
    {
        public static T Cast<T>(object o)
        {
            return (T) (dynamic) o;
        }
    }
