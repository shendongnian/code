    void Start()
    {
        int a = CalculateInt();
        string message = GetMessage(a);
        Console.Write(message);
    }
    
    int CalculateInt()
    {
        return b + c;
    }
    
    string GetMessage(int a)
    {
        return $"a is an Integer with the value {a}";
    }
