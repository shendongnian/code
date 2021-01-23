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
