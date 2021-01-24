    public static class Test
    {
        public static Reader<double> UseMethod(double x, double y) =>
            from a in Example.MyFuncStyleMethod(x)
            from b in Example.MyFuncStyleMethod(y)
            select a + b;
    }
