            Process process = new Process();
            process.StartInfo.FileName = "[program name here]";
            process.StartInfo.Arguments = "[arguments here]";
            process.StartInfo.WindowStyle = ProcessWindowStyle.Maximized;
            process.Start();
            process.WaitForExit();
            int code = process.ExitCode;
