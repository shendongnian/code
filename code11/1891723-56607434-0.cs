    bool bWow64 = false;
    IsWow64Process(Process.GetCurrentProcess().Handle, out bWow64);
    if (bWow64)
    {
        IntPtr OldValue = IntPtr.Zero;
        bool bRet = Wow64DisableWow64FsRedirection(out OldValue);
    }
    string sKey = @"HKEY_LOCAL_MACHINE\SOFTWARE\NPTMigration";
    string sFile = @"C:\temp\CDPRegExport.txt";
    using (Process process = new Process())
    {
        ProcessStartInfo psi = new ProcessStartInfo();
        psi.WindowStyle = ProcessWindowStyle.Hidden;
        psi.FileName = "reg";
        psi.Arguments = "export " + "" + sKey + "" + " " + "" + sFile + "";
        psi.RedirectStandardOutput = true;
        psi.UseShellExecute = false;
        process.StartInfo = psi;
        process.Start();
        using (StreamReader reader = process.StandardOutput)
        {
            string sResult = reader.ReadToEnd();
            Console.Write(sResult);
        }
    }
