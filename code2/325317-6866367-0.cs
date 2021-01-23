    void makeOutput(Func<int> _param)
    {
        makeOutput(_param());
    }
    
    void makeOutput(int _param)
    {
        Console.WriteLine( _param.ToString());
    }
