    public class MyServiceOptions
    {
        public int setting { get; set; }
    }
    public class MyService
    {
        public MyService(IOptions<MyServiceOptions> options)
        {
            // TODO: Capture options.
        }
    }
    public class MyServiceOptions<TMyService> : MyServiceOptions
        where TMyService : MyService
    {
    }
