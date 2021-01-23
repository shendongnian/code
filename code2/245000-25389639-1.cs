    // Get the path of the Acrobat executable:
    var printApplicationRegistryPath = "SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\App Paths\\Acrobat.exe;SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\App Paths\\AcroRD32.exe";
    var tokens = printApplicationRegistryPath.Split(new[] { ';' });
    var applicationPath = string.Empty;
    foreach (var s in tokens)
    {
        applicationPath = GetRegistryValue(s);
        if (!string.IsNullOrEmpty(applicationPath))
        {
            break;
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
