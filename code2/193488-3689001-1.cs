    var startInfo = new ProcessStartInfo
    {
        FileName = "my.exe",
        UseShellExecute = false,
        RedirectStandardOutput = true
    };
    using (var process = new Process { StartInfo = startInfo })
    {
        process.Start();
        string line;
        while ((line = process.StandardOutput.ReadLine()) != null)
        {
            //process line
        }
        process.WaitForExit();
    }
