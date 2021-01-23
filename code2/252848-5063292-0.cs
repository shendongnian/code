    class MyFactory
    {
        private static IMyFactory _instance;
        public static void Assign(IMyFactory factory) { _instance = factory; }
        public static T Create<T>() { return _instance.Create<T>(); }
    }
    
    interface IMyFactory
    {
        T Create<T>();
    }
    class MyFactoryImp : IMyFactory
    {
        //do whatever needed in here
        public T Create<T>(){ return new T(); }
    }
    
    
    class BaseClass<T>
    {
         T Value {get; set;}
         string Name {get; set;}
    }
    
    class ChildClass : BaseClass<int>
    {
         public void Test()
         {
             ChildClass bs = MyFactory.Create<ChildClass>(10);
         }
    }
    
    // start with this, you can easily switch implementation
    MyFactory.Assign(new MyFactoryImp());
