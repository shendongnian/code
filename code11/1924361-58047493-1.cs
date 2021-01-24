    public static void PythonKernel_Test()
    {
        var pi = new ProcessStartInfo
        {
            FileName = "python",
            Arguments = "test.py",
            RedirectStandardOutput = true,
            RedirectStandardError = true,
            CreateNoWindow = true,
        };
        var pythonProcess = new Process
        {
            StartInfo = pi,
        };
        pythonProcess.OutputDataReceived+= (s,e) => 
        {
            Console.WriteLine("OUT: {0}",e.Data);
        };
        pythonProcess.ErrorDataReceived+= (s,e) => 
        {
            Console.WriteLine("ERR: {0}",e.Data);
        };
        pythonProcess.Start();
        pythonProcess.BeginOutputReadLine();
        pythonProcess.BeginErrorReadLine();
        pythonProcess.WaitForExit();
    }
