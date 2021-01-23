    bool isCoolingDown = false;
    
    subject
        .Where(_ => !isCoolingDown)
        .Subscribe(
        i =>
        {
            DoStuff(i);
    
            isCoolingDown = true;
    
            Observable
                .Interval(cooldownInterval)
                .Take(1)
                .Subscribe(_ => isCoolingDown = false);
        });
