    public static class MyFunctions
    {
        [ExcelFunction]
        public static object Hello(params object[] values)
        {
            return "Hello " + DateTime.Now;
        }
    }
