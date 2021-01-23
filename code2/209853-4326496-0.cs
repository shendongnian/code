    public static bool FireUpProcess(Process process, string path, bool enableRaisingEvents, ProcessWindowStyle windowStyle) 
    { 
        //if path contains " ", surround it with quotes.
        //add /c and the path as parameters to the cmd process. 
        //Any other parameters can be added after the path.
        ProcessStartInfo psi = new ProcessStartInfo("cmd", "/c" + path ));            
        psi.WorkingDirectory = System.IO.Path.GetDirectoryName(@path);          
        psi.WindowStyle = windowStyle;          
        // Suscribe to the exit notification          
        process.EnableRaisingEvents = enableRaisingEvents;          
        // Disable to prevent multiple launchs          
        Framework.Check.LogWarning("LAUNCHING EXTERNAL DEVICE WITH PATH: " + path);          
        process.Start(); ...}
