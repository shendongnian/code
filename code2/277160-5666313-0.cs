    public interface IMyClass
    {
        string MyMethod();
    }
    public class MyClass : IMyClass
    {
        private readonly string myName;
        private readonly string myEtc;
        public MyClass(string name, string etc)
        {
            myName = name;
            myEtc = etc;
        }
       public string MyMethod()
       {
           return myName + myEtc;
       }
    }
 
    public class FactoryTest
    {
        public string GetMyString()
        {
            RegisterMyClass();
            return ObjectFactory.GetInstance<IMyClass>().MyMethod();
        }
        public void RegisterMyClass()
        {
            ObjectFactory.Initialize(
                  f => f.For<IMyClass>().Use(x => new MyClass("a", "b")));
        }
    }
