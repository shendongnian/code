    public class MyException :Exception
    {
        public int code { get; set; }
        public MyException(int c) { code = c; }
    }
