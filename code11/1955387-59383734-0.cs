    using (Process process = new Process())
    {
        process.StartInfo.FileName = "AcroRd32.exe";
        process.StartInfo.Arguments = "/T \"document1.pdf\"";
        process.StartInfo.UseShellExecute = false;
        process.StartInfo.RedirectStandardOutput = false;
    
        process.PriorityClass = ProcessPriorityClass.AboveNormal;
    
        process.Start();
    }
