    class MyClass
    {
        public override string ToString()
        {
            return "I am confused now";
        }
    }
    class InheritedClass : MyClass
    {
    }
    class Confused
    {
        public MyClass GetMyClass()
        {
            return new MyClass();
        }
        public T GetMyClass<T>() where T : MyClass, new()
        {
            return System.Activator.CreateInstance<T>();
        }
    }
    class Program
    {
        static void Main()
        {
            Confused c = new Confused();
            System.Console.WriteLine(c.GetMyClass());
            System.Console.WriteLine(c.GetMyClass<MyClass>());
            System.Console.WriteLine(c.GetMyClass<InheritedClass>());
        }
    }
