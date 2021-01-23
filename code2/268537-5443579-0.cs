    public delegate void DemoDelegate(string arg);
    public void MyMethod(DemoDelegate delegate)
    {
        // Call the delegate
        delegate("some string");
    }
