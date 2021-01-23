    public interface IMyObject
    {
        object Function1();
        object Function2(object arg1);
        object Function3(object arg1, object arg2);
    }
    class MyObject : IMyObject
    {
        public object Function1() { return null; }
        public object Function2(object arg1) { return null; }
        public object Function3(object arg1, object arg2) { return null; }
    }
    class MyObjectInterceptor : IMyObject
    {
        readonly IMyObject MyObject;
        public MyObjectInterceptor()
            : this(new MyObject())
        {
        }
        public MyObjectInterceptor(IMyObject myObject)
        {
            MyObject = myObject;
        }
        public object Function1()
        {
            Console.WriteLine("Intercepted Function1");
            return MyObject.Function1();
        }
        public object Function2(object arg1)
        {
            Console.WriteLine("Intercepted Function2");
            return MyObject.Function2(arg1);
        }
        public object Function3(object arg1, object arg2)
        {
            Console.WriteLine("Intercepted Function3");
            return MyObject.Function3(arg1, arg2);
        }
    }
