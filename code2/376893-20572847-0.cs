    static void Main(string[] args)
    {
        Tuple<int, bool> value = JustAMethod<int>(5, 3);
        if (value.Item2)
        {
            Console.WriteLine(value.Item1);
        }
        else
        {
            Console.WriteLine("Can't substract.");
        }
    }
    public static Tuple<T, bool> JustAMethod<T>(T arg1, T arg2)
    {
        dynamic dArg1 = (dynamic)arg1;
        dynamic dArg2 = (dynamic)arg2;
        dynamic ret;
        try
        {
            ret = dArg1 - dArg2;
            return new Tuple<T, bool>(ret, true);
        }
        catch
        {
            return new Tuple<T, bool>(default(T), false);
        }
    }
