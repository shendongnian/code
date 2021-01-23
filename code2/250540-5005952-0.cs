            System.Diagnostics.ProcessStartInfo processStartInfo = new System.Diagnostics.ProcessStartInfo("MyExe.exe", "parameters ...");
            int exitCode = 0;
            processStartInfo.RedirectStandardError = true;
            processStartInfo.RedirectStandardOutput = true;
            processStartInfo.CreateNoWindow = true;
            processStartInfo.UseShellExecute = false;
            System.Diagnostics.Process process =
            System.Diagnostics.Process.Start(processStartInfo);
    
            process.WaitForExit(); //wait for 20 sec
            exitCode = process.ExitCode;
            string stdout = process.StandardOutput.ReadToEnd();
            string stderr = process.StandardError.ReadToEnd();
            
    you should see the error string in stdout or stderr depending on how your console applicatione decided to output the failures.
