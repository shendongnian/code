            startInfo.WindowStyle = ProcessWindowStyle.Hidden;
            startInfo.CreateNoWindow = true;
            startInfo.UseShellExecute = false;
            startInfo.WorkingDirectory = folder;
            startInfo.RedirectStandardInput = true;
            startInfo.RedirectStandardOutput = true;
            startInfo.Arguments = args;
            Process process = new Process();
            process.StartInfo = startInfo;
            process.Start();
            var results = new List<string>();
            while (!process.StandardOutput.EndOfStream)
            {
                results.Add(process.StandardOutput.ReadLine());
            }
            return results;
