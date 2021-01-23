    public interface ITest { }
    public class InterfaceUser : ITest { }
    public class TestClass
    {
        void genericMethod<T>(List<T> myList) where T : ITest { }
        void testGeneric()
        {
            this.genericMethod(new List<InterfaceUser>());
        }
    }
