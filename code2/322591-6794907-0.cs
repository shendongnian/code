    public class ThreadStartParam
    {
        public string Str { get; set; }
        public StreamReader StreamReader { get; set; }
    }
    class Program
    {
        static void Main(string[] args)
        {
            var t = new Thread(YourMethod);
            var param = new ThreadStartParam();
            param.Str = "abc";
            param.StreamReader = new StreamReader();
            t.Start(param);
        }
        static void YourMethod(object param)
        {
            var p = (ThreadStartParam) param;
            // whatever
        }
    }
