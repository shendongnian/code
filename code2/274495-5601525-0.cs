    class Program
    {
        class Base<T> { }
        class Derived<T> : Base<T> { }
        class Another<T> { }
        class DerivedFromDerived<T> : Derived<T> { }
        static bool DerivedFromBase<T>(Type type)
        {
            return typeof(Base<T>).IsAssignableFrom(type);
        }
        static void Main(string[] args)
        {
            Console.WriteLine(DerivedFromBase<int>(typeof(Derived<int>)));            // true    
            Console.WriteLine(DerivedFromBase<int>(typeof(Another<int>)));            // false    
            Console.WriteLine(DerivedFromBase<int>(typeof(DerivedFromDerived<int>))); // true   
            Console.ReadKey(true);
        }
    }
