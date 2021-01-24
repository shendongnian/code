    public class GenericClass<TSomeClass> where TSomeClass : class, IInterface
    {
        public IInterface SomeMethod(TSomeClass someClass = null)
        {
            return SomeClass.SomeClassStaticInstance; //This now compiles!
        }
    }
