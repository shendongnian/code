    var reallyBadIdea = new ReallyBadIdea();
    GC.Collect(GC.MaxGeneration);
    GC.WaitForPendingFinalizers();
    GC.Collect(GC.MaxGeneration);
    // ...
    public class ReallyBadIdea
    {
        ~ReallyBadIdea()
        {
            while (true)
            {
                // ...
            }
        }
    }
