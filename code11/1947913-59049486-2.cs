    private T genericFormatterTest<T>(T x) where T: IConvertible
    {
        if (typeof(T) == typeof(int))
        {
            return (T)(object)(Convert.ToInt32(x) * Convert.ToInt32(x)); //squared
        }
        else
        {
            return (T)(object)(x + "\n");
        }
    }
