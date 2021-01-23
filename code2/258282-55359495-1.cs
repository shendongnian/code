  public static void RoboCopy(string src, string dst)
        {
            Process p = new Process();
            p.StartInfo.Arguments = string.Format("/C Robocopy {0} {1}", src, dst);
            p.StartInfo.FileName = "CMD.EXE";
            p.StartInfo.CreateNoWindow = true;
            p.StartInfo.UseShellExecute = false;
            p.Start();
            p.WaitForExit();
        }
As seen in: https://stackoverflow.com/questions/7890767/file-copy-using-robo-copy-and-process
