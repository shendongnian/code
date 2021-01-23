    private Dictionary<string, Action<int>> doMethods = new Dictionary<string, Action<int>>();
    public SomeClass()
    {
        Type t = typeof(SomeClass);
        var methods = t.GetMethods().Where(m => m.Name.StartsWith("Do"));
        foreach(var method in methods)
             doMethods.Add(method.Name, (Action<int>)Delegate.CreateDelegate(typeof(Action<int>), this, method, true));
    }
    public void ActionFunction(string name, int num)
    {
        this.doMethods[name](num);
    }
