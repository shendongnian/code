            boolean breakFlag = false;
            while (!breakFlag)
            {
                Thread.Sleep(5000);
                if (!System.IO.File.Exists("Command.bat")) continue;
                using (System.IO.StreamReader sr = System.IO.File.OpenText("Command.bat"))
                {
                    string s = "";
                    while ((s = sr.ReadLine()) != null)
                    {
                        if (s.Contains("mp4:production/CATCHUP/"))
                        {
                            RemoveEXELog();
                            Process p = new Process();
                            p.StartInfo.WorkingDirectory = "dump";
                            p.StartInfo.FileName = "test.exe"; 
                            p.StartInfo.Arguments = s; 
                            p.Start();
                            breakFlag = true;
                            break;
                        }
                    }
                }
