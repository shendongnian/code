    public static class Test<T> 
        where T : class, new()
    {
        public static List<T> ConvertData(List<T> oldDatas)
        {
            T instanceOfT = new T();
            Type typeOfT = typeof(T); // or instanceOfT.GetType();
            if(instanceOfT is string)
            {
                // T is a string
            }
            else if(instanceOfT is int)
            {
                // T is an int
            }
            // ...
        }
    }
