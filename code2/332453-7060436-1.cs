    var list = new List<Process>();
    
    var p1 = Process.Start(...);
    list.Add(p1);
    // similarly for other processes, or run this in a loop
    // later...
    var p = list[0];
    p.Kill();
    list.Remove(p);
    // ...
