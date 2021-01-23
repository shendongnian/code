    public class MyClassFactory : IMyClassFactory
    {
        private readonly IService service;
        public MyClassFactory(IService service)
        {
            this.service = service;
        }
        MyClass IMyClassFactory.CreateNew()
        {
            return new MyClass(this.service);
        }
    }
