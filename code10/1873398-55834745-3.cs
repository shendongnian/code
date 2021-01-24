    public static void InstanceMethod()
    {
        Console.WriteLine("Hello World");
    }
    public static void Example()
    {
        var list = new List<Instance>(5);
        list.Add(new Instance());
        list.ForEach(x => InstanceMethod());
    }
