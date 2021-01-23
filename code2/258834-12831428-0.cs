    public static void TakeScreenshot(string path) {
        try {
            InternalTakeScreenshot(path);
        } catch(Win32Exception) {
            var winDir = System.Environment.GetEnvironmentVariable("WINDIR");
            Process.Start(
                Path.Combine(winDir, "system32", "tscon.exe"),
                String.Format("{0} /dest:console", GetTerminalServicesSessionId()))
            .WaitForExit();
    
            InternalTakeScreenshot(path);
        }
    }
    static void InternalTakeScreenshot(string path) {
        var point = new System.Drawing.Point(0,0);
        var bounds = System.Windows.Forms.Screen.GetBounds(point);
        
        var size = new System.Drawing.Size(bounds.Width, bounds.Height);
        var screenshot = new System.Drawing.Bitmap(bounds.Width, bounds.Height);
        var g = System.Drawing.Graphics.FromImage(screenshot)
        g.CopyFromScreen(0,0,0,0,size);
        
        screenshot.Save(path, System.Drawing.Imaging.ImageFormat.Jpeg); 
    }
    [DllImport("kernel32.dll")]
    static extern bool ProcessIdToSessionId(uint dwProcessId, out uint pSessionId);
    static uint GetTerminalServicesSessionId()
    {
        var proc = Process.GetCurrentProcess();
        var pid = proc.Id;
        var sessionId = 0U;
        if(ProcessIdToSessionId((uint)pid, out sessionId))
            return sessionId;
        return 1U; // fallback, the console session is session 1
    }
  
