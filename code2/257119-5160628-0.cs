    public static void Foo(int x)
    {
        ParameterizedThreadStart p = new ParameterizedThreadStart(o => Bar((int)o));overload for Bar matches delegate ParameterizedThreadStart
        Thread myThread = new Thread(p);
        myThread.Start(x);
    }
    private static void Bar(int x)
    {
        // do work
    }
