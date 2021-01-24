    SafeAccessTokenHandle safeAccessTokenHandle;  
    bool returnValue = LogonUser(ExeUsername, ExeDomain, ExePassword,  
            LOGON32_LOGON_INTERACTIVE, LOGON32_PROVIDER_DEFAULT,  
            out safeAccessTokenHandle);
    if (false == returnValue)  
    {  
        int ret = Marshal.GetLastWin32Error();  
        throw new System.ComponentModel.Win32Exception(ret);  
    }  
    WindowsIdentity.RunImpersonated(safeAccessTokenHandle, () =>  
    {  
         var startInfo = new ProcessStartInfo()
         {
             FileName = ExeLocation,
             Arguments = string.Format("\"{0}\"{1}", ScriptLocation, Arguments),
             UseShellExecute = false,
             RedirectStandardOutput = true,
             RedirectStandardError = true,
             WorkingDirectory = AppDir,
             CreateNoWindow = true,
             UserName = ExeUsername,
             Password = ExePassword,
             Domain = ExeDomain
         };
         using (Process process = Process.Start(startInfo))
         {
             using (StreamReader reader = process.StandardOutput)
             {
                 output = reader.ReadToEnd();
             }
             using (StreamReader reader = process.StandardError)
             {
                 error = reader.ReadToEnd();
             }
    
             process.WaitForExit();
             if (process.ExitCode != 0)
             {
                 throw new Exception(string.IsNullOrEmpty(output) ? error : output);
             }
         } 
    );  
