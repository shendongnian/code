    System.Diagnostics.Stopwatch aTimer = new System.Diagnostics.Stopwatch();
    aTimer.Start();
    var IsThirteenOrphans = !required.Except(array).Any();
    aTimer.Stop();
    System.Diagnostics.Stopwatch bTimer = new System.Diagnostics.Stopwatch();
    bTimer.Start();
    bool notContains = false;
    foreach (var iddd in required)
    {
        foreach (var ar in array)
        {
            if (iddd == ar) notContains=true;            
        }
        if (notContains == false) break;
    }
    bTimer.Stop();
