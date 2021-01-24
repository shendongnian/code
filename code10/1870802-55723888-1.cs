    public interface IInterface
    {
        int GetId();
    }
    // Contra-variant and covariant generic type argument can be used only in interfaces and delegates
    public interface IClassA<out T> where T : IInterface 
    {
    }
    
    public class ClassA<T> : IClassA<IInterface> where T : IInterface { }
    public class ClassB : IInterface
    {
        public int GetId()
        {
            return 1;
        }
    }
    public class ClassC
    {
        List<IClassA<IInterface>> list = new List<IClassA<IInterface>>();
        public void Add(IClassA<IInterface> item)
        {
            list.Add(item);
        }
    }
    public class Test
    {
        public static void Run()
        {
            ClassC classC = new ClassC();
            ClassA<ClassB> classA = new ClassA<ClassB>();
            classC.Add(classA);
        }
    }
