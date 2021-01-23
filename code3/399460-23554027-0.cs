    /// <summary>
    /// Handles the OK button click.
    /// </summary>
    private void HandleOKButtonClick() {
    string executableFolder = "";
    	
    #if UNITY_EDITOR
    executableFolder = Path.Combine(Application.dataPath, "../../../../build/Include/Executables");
    #else
    executableFolder = Path.Combine(Application.dataPath, "Include/Executables");
    #endif
    
    EstablishSocketServer();
    
    var proc = new Process {
    	StartInfo = new ProcessStartInfo {
    		FileName = Path.Combine(executableFolder, "WordConverter.exe"),
    		Arguments = locationField.value + " " + _ipAddress.ToString() + " " + SOCKET_PORT.ToString(), 
    		UseShellExecute = false,
    		RedirectStandardOutput = true,
    		CreateNoWindow = true
    	}
    };
    
    proc.Start();
