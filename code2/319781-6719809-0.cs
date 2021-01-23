    bool needRemove = false, needClear = false;
    using (System.IO.StreamReader sr = System.IO.File.OpenText("Command.bat"))
    {
        string s = "";
        while ((s = sr.ReadLine()) != null)
        {
            if (s.Contains("mp4:production/CATCHUP/"))
            {
                needRemove = true;
                Process p = new Process();
                p.StartInfo.WorkingDirectory = "dump";
                p.StartInfo.FileName = "test.exe";
                p.StartInfo.Arguments = s;
                p.Start();
                needClear = true;
            }
        }
    }
    if (needRemove) RemoveEXELog(); // Deletes a specific keyword from Command.bat
    if (needClear) ClearLog(); // Deletes Command.bat and then creates a new empty Command.bat
