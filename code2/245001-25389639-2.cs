    string applicationPath;
    var printApplicationRegistryPaths = new[]
    {
        @"SOFTWARE\Microsoft\Windows\CurrentVersion\App Paths\Acrobat.exe",
        @"SOFTWARE\Microsoft\Windows\CurrentVersion\App Paths\AcroRD32.exe"
    };
    foreach (var printApplicationRegistryPath in printApplicationRegistryPaths)
    {
        using (var regKeyAppRoot = Registry.LocalMachine.OpenSubKey(printApplicationRegistryPath))
        {
            if (regKeyAppRoot == null)
            {
                continue;
            }
            applicationPath = (string)regKeyAppRoot.GetValue(null); 
            if (!string.IsNullOrEmpty(applicationPath))
            {
                return applicationPath;
            }
        }
    }
    // Print to Acrobat
	const string flagNoSplashScreen = "/s";
	const string flagOpenMinimized = "/h";
	var flagPrintFileToPrinter = string.Format("/t \"{0}\" \"{1}\"", printFileName, printerName); 
	var args = string.Format("{0} {1} {2}", flagNoSplashScreen, flagOpenMinimized, flagPrintFileToPrinter);
	var startInfo = new ProcessStartInfo
	{
		FileName = printApplicationPath, 
		Arguments = args, 
		CreateNoWindow = true, 
		ErrorDialog = false, 
		UseShellExecute = false, 
		WindowStyle = ProcessWindowStyle.Hidden
	};
	var process = Process.Start(startInfo);
	
	// Close Acrobat regardless of version
	if (process != null)
    {
        process.WaitForInputIdle();
        process.CloseMainWindow();
    }
