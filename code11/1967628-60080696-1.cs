    public static class Test
    {
        public static Reader<double> UseMethod(double x, double y) =>
            from a in Reader.MyFuncStyleMethod(x)
            from b in Reader.MyFuncStyleMethod(y)
            select a + b;
    }
