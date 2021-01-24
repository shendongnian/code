    public void InstanceMethod(Instance x)
    {
        Console.WriteLine("Hello World");
    }
    public void Example()
    {
        var list = new List<Instance>(5);
        list.Add(new Instance());
        list.ForEach(InstanceMethod);
    }
