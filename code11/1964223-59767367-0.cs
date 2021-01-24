    System.Diagnostics.StackTrace st = new System.Diagnostics.StackTrace();
    var f = st.GetFrames();
    var names = f.Select(f => f.GetMethod().Name).ToList();
    if (names.Contains("DoSomething4"))
    {
        var a = 0; // Set breakpoint in this line or use Debugger.Launch()
    }
