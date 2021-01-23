    void Main()
    {
        Action<int> doSomething = OnClick;
        doSomething += i=> Console.WriteLine("test");
        OnClick(1);
    }
    
    private void OnClick(int i)
    {
        Console.WriteLine("clicked");
    }
