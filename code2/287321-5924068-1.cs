    void Hunt(IList<Gull> gulls)
    {
        if (gulls.Empty())
           return;
        
        var target = gulls.First();
        TargetAcquired(target, gulls);
    }
    
    void TargetAcquired(Gull target, IList<Gull> gulls)
    {
        var balloon = new WaterBalloon(weightKg: 20);
    
        this.Cannon.Fire(balloon);
    
        if (balloon.Hit)
        {
           TargetHit(target, gulls);
        }
        else
           TargetMissed(target, gulls);
    }
    
    void TargetHit(Gull target, IList<Gull> gulls)
    {
        Console.WriteLine("Suck on it {0}!", target.Name);
        Hunt(gulls);
    }
    
    void TargetMissed(Gull target, IList<Gull> gulls)
    {
        Console.WriteLine("I'll get ya!");
        TargetAcquired(target, gulls);
    }
