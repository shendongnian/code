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
    Office 97   -  7
    Office 98   -  8
    Office 2000 -  9
    Office XP   - 10
    Office 2003 - 11
    Office 2007 - 12
    Office 2010 - 14 
    Office 2013 - 15
    Office 2016 - 16
