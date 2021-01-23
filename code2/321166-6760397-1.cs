    // This is the code for the base process
    Process myProcess = new Process();
    // Start a new instance of this program but specify the 'spawned' version.
    ProcessStartInfo myProcessStartInfo = new ProcessStartInfo(args[0], "spawn");
    myProcessStartInfo.UseShellExecute = false;
    myProcessStartInfo.RedirectStandardOutput = true;
    myProcess.StartInfo = myProcessStartInfo;
    myProcess.Start();
    StreamReader myStreamReader = myProcess.StandardOutput;
    // Read the standard output of the spawned process.
    string myString = myStreamReader.ReadLine();
    Console.WriteLine(myString);
    myProcess.WaitForExit();
    myProcess.Close();
