    var startInfo = new ProcessStartInfo
    {
        FileName = "my.exe",
        UseShellExecute = false,
        RedirectStandardOutput = true,
        RedirectStandardError = true
    };
    using (var process = new Process { StartInfo = startInfo })
    {
        process.ErrorDataReceived += (s, e) =>
        {
            string line = e.Data;            
            //process stderr lines
        };
        process.OutputDataReceived += (s, e) =>
        {
            string line = e.Data;
            //process stdout lines
        };
        process.Start();
        process.BeginErrorReadLine();
        process.BeginOutputReadLine();
        
        process.WaitForExit();
    }
