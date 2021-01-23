    public void PrintToString(IEnumerable<object> things)
    {
        foreach(var obj in things)
        {
            Console.WriteLine(obj.ToString());
        }
    }
    
    public static void Main()
    {
        List<string> strings = new List<string>() { "one", "two", "three" };
        List<MyClass> myClasses = new List<MyClass>();
    
        // add elements to myClasses
    
        PrintToString(strings);
        PrintToString(myClasses);
    }
