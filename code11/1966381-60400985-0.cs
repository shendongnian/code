            // NOTE: This code is just a crude example.
            
            // Invoke the offline installer.
            System.Diagnostics.Process process = new System.Diagnostics.Process();
            System.Diagnostics.ProcessStartInfo startInfo = new System.Diagnostics.ProcessStartInfo();
            startInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
            startInfo.FileName = "cmd.exe";
            startInfo.Arguments = "/C path\\to\\offline\\installer\\NDP462-KB3151800-x86-x64-AllOS-ENU.exe";
            process.StartInfo = startInfo;
            process.Start();
            
            process.WaitForExit();
            
            // Handle the exit code.
            if (process.ExitCode == ...)
            {
                ...
            }
