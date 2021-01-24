    private class MyClass { }
    private class MyClassWithInterface : IMyClass { }
    private interface IMyClass { }
    
    static void Main(string[] args)
    {
        ITakeLists(new List<MyClass>()); // it is
        ITakeLists(new List<MyClassWithInterface>()); // isInstanceOf
        ITakeLists(new List<int>()); // it is not
        //ITakeLists(new MyClass()); // Error, is not derived from IEnumerable
    }
    
    private static void ITakeLists(IEnumerable myList)
    {
        if (myList is List<MyClass>)
            Console.WriteLine("it is");
        else if(typeof(IMyClass).IsAssignableFrom(myList.GetType().GetGenericArguments()[0]))
            Console.WriteLine("isInstanceOf");
        else
            Console.WriteLine("it is not :(");
    }
