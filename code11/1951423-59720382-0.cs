                    Process GetSessionID = new Process();
                    GetSessionID.StartInfo.FileName = "CMD.exe";
                    GetSessionID.StartInfo.Arguments = "/C" + "for /f \"skip=1 tokens=3\" %1 in ('query user " + Username + "/server:" + ComputerName + "') do @echo %1";
                    GetSessionID.StartInfo.RedirectStandardOutput = true;
                    GetSessionID.StartInfo.UseShellExecute = false;
                    GetSessionID.StartInfo.CreateNoWindow = true;
                    GetSessionID.Start();
                    SessionIDOutput = GetSessionID.StandardOutput.ReadToEnd();
                    GetSessionID.WaitForExit();
                    DoAllTheThingsTextBox.Text = SessionIDOutput;
                    if (GetSessionID.HasExited == true)
                    {
                        var digitArray = DoAllTheThingsTextBox.Text.Where(Char.IsDigit).ToArray();
                        SessionID = new String(digitArray);
                        if (MouseControlCheck.Checked == true)
                        {
                            Process Process = new Process();
                            ProcessStartInfo startInfo = new ProcessStartInfo("CMD.exe", "/C" + "mstsc /shadow:" + SessionID + " /v " + ComputerName + " /control");
                            startInfo.CreateNoWindow = true;
                            startInfo.UseShellExecute = false;
                            Process = Process.Start(startInfo);
                        }
                        else
                        {
                            Process Process = new Process();
                            ProcessStartInfo startInfo = new ProcessStartInfo("CMD.exe", "/C" + "mstsc /shadow:" + SessionID + " /v " + ComputerName);
                            startInfo.CreateNoWindow = true;
                            startInfo.UseShellExecute = false;
                            Process = Process.Start(startInfo);
                        }
                    }
