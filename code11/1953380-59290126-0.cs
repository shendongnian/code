    public interface IInterface
    {
    }
    
    public class GenericClass<TSomeClass>
        where TSomeClass : IInterface
    {
        //Not sure what the input parameter is for?
        public IInterface SomeMethod(TSomeClass someClass = null)
        {
            return SomeClass.SomeClassStaticInstance;                  
        }
    }
    
    public class SomeClass : IInterface
    {
        public static IInterface SomeClassStaticInstance = new SomeClass();
    }
