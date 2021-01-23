    static public void Test2<T>(ref T s)
        {
            if (s is string)
            {
                s = (T)(Object)"Hello world!";
            }
    }
