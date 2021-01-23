    public void FindInstance(Action action)
    {
        dynamic instance = action.Target;
        Console.WriteLine(instance.Property1);
    }
