    public class ClassA { }
    public class MyGenericClass<T>: ClassA { }
    
    class Program
    {
        static void Main()
        {
            var result = DerivesFrom(typeof(MyGenericClass<>), typeof(ClassA));
            Console.WriteLine(result); // prints True
        }
    
        private static bool DerivesFrom(Type rType, Type rDerivedType)
        {
            return rType.IsSubclassOf(rDerivedType);
        }
    }
