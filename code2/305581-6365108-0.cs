    public static MyClass FirstOrDefault(this IEnumerable<MyClass> source)
    {
        foreach (var x in source)
        {
            return x;
        }
        return new MyClass("hello world"); 
        //OR, could be made a bit nicer by making a static method in your class
        return MyClass.Default();
    }
