    public static class Example
    { 
        public static Reader<double> MyFuncStyleMethod(double value) =>
            Reader.Ask.Map(env => env.MyFuncStyleMethod(value));
    }
