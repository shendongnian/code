    private void Run()
    {
        var x = singleton<main>.instance;
        Console.WriteLine($"x.UserId = {x.UserID}");
    
        var y = singleton<main>.instance;
        Console.WriteLine($"y.UserId = {y.UserID}");
    
        x.UserID++;
        Console.WriteLine($"x.UserId = {x.UserID}");
        Console.WriteLine($"y.UserId = {y.UserID}");
    
        var user = new User();
        Console.WriteLine($"User.Name = {user.Name()}");
    
        var mp = MissPiggy.Instance;
    }
