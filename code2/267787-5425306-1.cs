    System.Threading.Timer WorkTimer;
    
    // Somewhere in your initialization:
    
    WorkTimer = new System.Threading.Timer((state) =>
        {
            DoWork();
        }, null, TimeSpan.FromMinutes(5.0), TimeSpan.FromMinutes(5.0));
