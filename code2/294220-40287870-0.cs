    // Spawn your process as you normally would... but also have it dump the environment varaibles
    Process process = new Process();
    process.StartInfo.FileName = mybatfile.bat;
    process.StartInfo.Arguments = @"&&set>>envirodump.txt";
    process.StartInfo.UseShellExecute = false;
    process.StartInfo.RedirectStandardOutput = true;
    process.StartInfo.RedirectStandardError = false;
    process.Start();
    string output = process.StandardOutput.ReadToEnd();
    process.WaitForExit();
    // Read the environment variable lines into a string array
    string[] envirolines = File.ReadAllLines("envirodump.txt");
    File.Delete("envirodump.txt");
    
    // Now simply set the environment variables in the parent process
    foreach(string line in a)
    {
        string var = line.Split('=')[0];
        string val = line.Split('=')[1];
        Environment.SetEnvironmentVariable(var, val);
    } 
