    public void Process(string param1, List<string> param2 = null) 
    {
        param2 = param2 ?? new List<string>();
        // or starting with C# 8
        param2 ??= new List<string>();
    }
