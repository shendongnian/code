    System.Diagnostics.ProcessStartInfo procStartInfo = new System.Diagnostics.ProcessStartInfo
                {
                    WindowStyle = System.Diagnostics.ProcessWindowStyle.Normal,
                    FileName = "cmd.exe",
                    RedirectStandardInput = true,
                    UseShellExecute = false,
                    Arguments = "/C reg query \"HKEY_CLASSES_ROOT\\Word.Application\\CurVer\""
                };
    
    
                procStartInfo.RedirectStandardOutput = true;
                procStartInfo.RedirectStandardError = true;
                procStartInfo.UseShellExecute = false;
                procStartInfo.CreateNoWindow = true;
                System.Diagnostics.Process proc = new System.Diagnostics.Process();
                proc.StartInfo = procStartInfo;
                proc.Start();
                string output = proc.StandardOutput.ReadToEnd();
    
                Console.WriteLine("Output: " + output);
    
                string version = System.Text.RegularExpressions.Regex.Replace(output, "(.*)(Word\\.Application\\.)(\\d+)(.*)", "$3", System.Text.RegularExpressions.RegexOptions.Singleline);
                Console.WriteLine("Office version: " + version);
    
                Console.Read();
