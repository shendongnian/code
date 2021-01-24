    // Whatever your top level abstract class is
    public abstract class SomeAbstarctClass
    {
    
    }
    
    // Interface that defines the signature of the Test method, but has no implementation detail.
    // No need to define it as virtual here, since there is no implementation
    public interface ITestMethodInterface
    {
        void Test();
    }
    
    // Inherit from the absract class and implement the interface. This forces the new class to implement the interface, and therefore the Test method
    public class ClassA : SomeAbstarctClass, ITestMethodInterface
    {
        // This CAN, if needed be virtual, but I would recommend if it isn't absolutely needed for a hierarchy to simply implement it here and use the Interface in ClassB
        // to force the derviced class to implement it instead.
        public void Test()
        {
            // Class A's implementation of Test()
        }
    }
    
    // Here's where it might get complicated, if you MUST have a hierachy where Class B MUST inherit from Class A instead of SomeAbstractClass, then the implementation will carry over
    // and it becomes difficult to FORCE the derviced class to override from ClassA
    public class ClassB : SomeAbstarctClass, ITestMethodInterface
    {
        public void Test()
        {
            // Class B's implementation of Test()
        }
    }
