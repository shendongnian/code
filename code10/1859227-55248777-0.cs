    public void gHook_KeyDown(object sender, KeyEventArgs e)
    {
        keyDict[e.KeyCode].Invoke();
    }
    public void SomeFunction()
    {
        Console.WriteLine("called some function");
    }
