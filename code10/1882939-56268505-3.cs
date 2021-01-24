    public class MyService1 : MyService
    {
        public MyService1(IOptions<MyServiceOptions<MyService1>> options>):base(options) 
        {
        }
     }
