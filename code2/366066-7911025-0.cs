    ProcessStartInfo info = new ProcessStartInfo("binary.exe");
    info.RedirectStandardInput = true;
    info.RedirectStandardOutput = true;
    Process p = Process.Start(info);
    string Input;
    // Read input file into Input here
    StreamWriter w = new StreamWriter(p.StandardInput);
    w.Write(Input);
    w.Dispose();
    StreamReader r = new StreamReader(p.StandardOutput);
    string Output = r.ReadToEnd();
    r.Dispose();
    // Write Output to the output file
    p.WaitForExit();
