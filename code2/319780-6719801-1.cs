    private void CheckLog()
        {
            bool _found;
            while (true)
            {
                string s = "";
                _found = false;
                Thread.Sleep(5000);
                if (!System.IO.File.Exists("Command.bat")) continue;
                using (System.IO.StreamReader sr = System.IO.File.OpenText("Command.bat"))
                {
                    while ((s = sr.ReadLine()) != null)
                    {
                        if (s.Contains("mp4:production/CATCHUP/"))
                        {
                           _found = true;
                           break;
                        }
                    }
                }
                if (_found)
                {
                     RemoveEXELog(); // Deletes a specific keyword from Command.bat
                     Process p = new Process();
                     p.StartInfo.WorkingDirectory = "dump";
                     p.StartInfo.FileName = "test.exe";
                     p.StartInfo.Arguments = s;
                     p.Start();
                     ClearLog(); // Deletes Command.bat and then creates a new empty Command.bat
                }
            }
        }
