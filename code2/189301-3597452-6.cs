    Console.Write("Press Enter to start the timer.");
    Console.ReadLine();
    var t = new System.Threading.Timer(
        state => { Console.WriteLine(DateTime.Now); },
        null,
        0,
        1000
    );
    Console.Write("Press Enter to set t to null.");
    Console.ReadLine();
    // This will not stop the timer. It actually does nothing at all to the timer
    // to which t has been assigned. HOWEVER, if/when the GC comes around to collect
    // garbage, it will see that said timer has no active references; and so it will
    // collect (and therefore finalize) it.
    t = null;
    Console.Write("Press Enter again to perform a garbage collection.");
    Console.ReadLine();
    // This WILL cause the timer to stop, as there is code in the type's
    // finalizer to stop it.
    GC.Collect();
    Console.Write("t is null and garbage has been collected. Press Enter to quit.");
    Console.ReadLine();
