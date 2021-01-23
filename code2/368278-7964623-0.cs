    namespace ConsoleApplication2
    {
        class Program
        {
            static void Main(string[] args)
            {
                MyClass<SomeClass> mc = new MyClass<SomeClass>();
                mc.SomeMethod(new SomeClassNested());
            }
        }
        public interface ISomeInterface
        {
        }
        public class SomeClass
        {
        }
        public class SomeClassNested : SomeClass, ISomeInterface
        {
        }
        public class MyClass<T>
        {
            public void SomeMethod(T t)
            {
                // Compiles, no errors at runtime
                ISomeInterface obj1 = (ISomeInterface)t;
            }
        }
    }
