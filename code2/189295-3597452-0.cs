    var t = new System.Timers.Timer(1000.0);
    t.AutoReset = true;
    t.Elapsed += (sender, e) => Console.WriteLine(DateTime.Now);
    Console.ReadKey();
    t.Start();
    Console.ReadKey();
    t = null; // this won't stop it
    Console.ReadKey();
    GC.Collect(); // nor will this
    Console.ReadKey();
