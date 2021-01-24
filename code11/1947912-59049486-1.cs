    private T genericFormatterTest<T>(T x)
    {
        if (typeof(T) == typeof(int))
        {
            return (T)(object)((int)(object)x * (int)(object)x); //squared
        }
        else
        {
            return (T)(object)(x + "\n");
        }
    }
