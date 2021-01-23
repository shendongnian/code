    private static Assembly GetWebEntryAssembly()
    { 
        var frames = new StackTrace().GetFrames();
        var i = frames.FirstOrDefault(c => Assembly.GetAssembly(c.GetMethod().DeclaringType).FullName != Assembly.GetExecutingAssembly().FullName).GetMethod().DeclaringType;
        return Assembly.GetAssembly(i);
    }
