    void m_Worker_DoWork(object sender, DoWorkEventArgs e)
    {
        int exec = 1;
        while (CommandQueue.Count > 0)
        {
            if (e.Cancel)
            {
                e.Result = 1;
                return;
            }
            WriteLine("Running command {0}, {1} remaining.", exec++, CommandQueue.Count);
            StagedCommand command = CommandQueue.Peek();
            try
            {
                if (command.Pre != null) command.Pre();
                int result = ShellExec(command.Command);
                if (command.Post != null) command.Post();
                CommandQueue.Dequeue();
                if (result != 0)
                {
                    e.Result = result;
                    return;
               }
            }
            catch (Exception exc)
            {
                WriteLine("Error: {0}", exc.Message);
                e.Result = 1;
                return;
            }
        }
        WriteLine("All commands executed successfully.");
        e.Result = 0;
        return;
    }
        int ShellExec(String command)
        {
            WriteLine(command);
            Style = ProgressBarStyle.Marquee;
            ProcessStartInfo info = new ProcessStartInfo
            {
                UseShellExecute = false,
                LoadUserProfile = true,
                ErrorDialog = false,
                CreateNoWindow = true,
                WindowStyle = ProcessWindowStyle.Hidden,
                RedirectStandardOutput = true,
                StandardOutputEncoding = Encoding.UTF8,
                RedirectStandardError = true,
                StandardErrorEncoding = Encoding.UTF8,
                FileName = "cmd.exe",
                Arguments = "/c " + command
            };
            Process shell = new Process();
            shell.StartInfo = info;
            shell.EnableRaisingEvents = true;
            shell.ErrorDataReceived += new DataReceivedEventHandler(ShellErrorDataReceived);
            shell.OutputDataReceived += new DataReceivedEventHandler(ShellOutputDataReceived);
            shell.Start();
            shell.BeginErrorReadLine();
            shell.BeginOutputReadLine();
            shell.WaitForExit();
            return shell.ExitCode;
        }
