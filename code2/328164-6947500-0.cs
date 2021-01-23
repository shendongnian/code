    public static void MyMethod(int x, List<string> y) { }
    public static void MyMethod(int x)
    {
        MyMethod(x, Enumerable<string>.Empty());
    }
