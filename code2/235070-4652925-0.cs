        abstract class TypeBase
        {
            static TypeBase()
            {
                Type<int>.Name = "int";
                Type<long>.Name = "long";
                Type<double>.Name = "double";
            }
        }
        class Type<T> : TypeBase
        {
            static Type() 
            {
                new Type<object>();
            }
            public static string Name { get; internal set; }
        }
        class Program
        {
            Console.WriteLine(Type<int>.Name);
        }
