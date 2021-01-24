    static class ReturnConstant<T>
    {
        public static T FiveOrHello()
        {
            if (typeof(T) == typeof(int))
            {
                return (T)(object)5;
            }
            else if (typeof(T) == typeof(string))
            {
                return (T)(object)"Hello!";
            }
            else
            {
                throw new NotImplementedException("OH NO");
            }
        }
    }
