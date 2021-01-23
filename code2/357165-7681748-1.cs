    public void AnotherMethod()
    {
        DoSomething(ShowSuccess); // ShowSuccess will be called when done
    }
    public void ShowSuccess()
    {
        Console.WriteLine("Success!");
    }
