    var t = new System.Timers.Timer(1000.0);
    t.AutoReset = true;
    t.Elapsed += (sender, e) => Console.WriteLine(DateTime.Now);
    Console.Write("Press Enter to start the timer.");
    Console.ReadLine();
    t.Start();
    Console.Write("Press Enter to set t to null.");
    Console.ReadLine();
    // This will not stop the timer. It actually does nothing at all to the timer
    // to which t has been assigned.
    t = null;
    Console.Write("Press Enter again to perform a garbage collection.");
    Console.ReadLine();
    // This STILL will not stop the timer, as t was not the only reference to it
    // (we created a new one when we added a handler to the Elapsed event).
    GC.Collect();
    Console.Write("t is null and garbage has been collected. Press Enter to quit.");
    Console.ReadLine();
