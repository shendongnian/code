    public class Foo<T>
    {
        Foo()
        {
            Console.WriteLine("T={0}", typeof(T));
        }
        public static void DummyMethod() {}
    }
    ...
    Foo<int>.DummyMethod(); // Executes static constructor first
    Foo<string>.DummyMethod(); // Executes static constructor first
    Foo<string>.DummyMethod(); // Type is already initialized; no more output
