    var list = new List<Process>();
    
    var p1 = Process.Start(...);
    list.Add(p1);
    // similarly for other processes, or run this in a loop
    // later...
    p1.Kill();
    list.Remove(p1);
    // ...
