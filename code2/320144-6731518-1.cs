    private void CheckLog()
        {
            //bool _found; //not needed anymore
            while (!Singleton.Instance.Found)
            {
                //_found = false;
                Thread.Sleep(5000);
                if (!System.IO.File.Exists("Command.bat")) continue;
                using (System.IO.StreamReader sr = System.IO.File.OpenText("Command.bat"))
                {
                    while ((s = sr.ReadLine()) != null)
                    {
                        if (s.Contains("mp4:production/CATCHUP/"))
                        {
                            Singleton.Instance.Found = true;
                            break;
                        }
                    }
                }
                if (Singleton.Instance.Found)
                {
                    // Deletes filename in the log file, as the filename is instead handled by p.start
                    var result = Regex.Replace(s, @"rtmpdump", string.Empty);
                    s = result;
                    RemoveEXELog(); // Deletes a specific keyword from Command.bat
                    RemoveHostFile();
                    Process p = new Process();
                    p.StartInfo.WorkingDirectory = "dump";
                    p.StartInfo.FileName = "test.exe";
                    p.StartInfo.Arguments = s;
                    p.Start();
                    p.WaitForExit();
                    MessageBox.Show("Operation Successful!");
                    string myPath = @"dump";
                    System.Diagnostics.Process prc = new System.Diagnostics.Process();
                    prc.StartInfo.FileName = myPath;
                    prc.Start();
                    ClearLog(); // Deletes Command.bat and then creates a new empty            Command.bat
                    LogTrue();
            }
        }
    }
