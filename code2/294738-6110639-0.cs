    using (profiler.Step("Doing complex stuff"))
    {
        using (profiler.Step("Step A"))
        { // something more interesting here
            Thread.Sleep(100);
        }
        using (profiler.Step("Step B"))
        { // and here
            Thread.Sleep(250);
        }
    }
