            ProcessStartInfo psi = new ProcessStartInfo();
            psi.CreateNoWindow = false;
            psi.UseShellExecute = false;
            psi.FileName = "C:\\my.exe";
            psi.WindowStyle = ProcessWindowStyle.Hidden;
            psi.RedirectStandardOutput = true;
            psi.RedirectStandardError = true;
            using (Process exeProcess = Process.Start(psi))
            {
                exeProcess.WaitForExit();
                var exitCode = exeProcess.ExitCode;
                var output = exeProcess.StandardOutput.ReadToEnd();
                var error = exeProcess.StandardError.ReadToEnd();
                    
                if (output.Length > 0)
                {
                    // you have some output
                }
                    
                    
                if(error.Length > 0)
                {
                    // you have some error details
                }
            }
