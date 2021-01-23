    public interface IDoSomething
    {
        void DoSomething();
    }
    public static void Foo<T>(LinkedList<T> list) where T : IDoSomething
    {
        foreach (T o in list)
        {
            o.DoSomething();
        }
    }
