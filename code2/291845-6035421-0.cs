    void Main()
    {
        double foo = 0;
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
            thread.Abort();
        }
        message.Dump();
    }
    
    public double GetFoo() {
        double a = RandomProvider.Next(2, 5); 
        while (a == 3) { RandomProvider.Next(2, 5);} 
        double b = RandomProvider.Next(2, 5); 
        double c = b /a; 
        double e = RandomProvider.Next(8, 11); 
        while (e == 9) { RandomProvider.Next(8,11); } 
        double f = b / e;
        return f;
    }
