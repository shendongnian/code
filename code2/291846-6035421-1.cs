    void Main()
    {
        double foo = 0;
        _abort = false;
        var thread = new Thread(() => foo = GetFoo());
        thread.Start();
        string message;
        if(thread.Join(1000))
        {
            message = foo.ToString();
        }
        else 
        {
            message = "Process took too long";
            _abort = true;
        }
        message.Dump();
    }
    
    // This could be anywhere, as long as both Main and GetFoo have access to it.
    bool _abort;
    
    public double GetFoo() {
        double a = RandomProvider.Next(2, 5); 
        while (a == 3 && !_abort) { RandomProvider.Next(2, 5);} 
        double b = RandomProvider.Next(2, 5); 
        double c = b /a; 
        double e = RandomProvider.Next(8, 11); 
        while (e == 9 && !_abort) { RandomProvider.Next(8,11); } 
        double f = b / e;
        return _abort ? 0 : f;
    }
