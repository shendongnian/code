    // dependent class using an abstract class
    public abstract class BaseClass
    {
         public abstract void SomeMethod();
    }
    public class ClassForTesting
    {
        public BaseClass SomeMember { get; private set; }
        public ClassForTesting(BaseClass baseClass)
        {
            if (baseClass == null) throw new ArgumentNullException("baseClass");
            SomeMember = baseClass;
        }
    }
