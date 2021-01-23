    // causes a deadlock when built with release config and no debugger attached
    // building in debug mode and/or attaching the debugger might keep
    // badIdea alive for longer, in which case you won't see the deadlock
    var badIdea = new BadIdea();
    Monitor.Enter(badIdea);
    GC.Collect(GC.MaxGeneration);
    GC.WaitForPendingFinalizers();
    GC.Collect(GC.MaxGeneration);
    // ...
    public class BadIdea
    {
        ~BadIdea()
        {
            lock (this)
            {
                // ...
            }
        }
    }
