            var p = new Process();
            p.StartInfo.RedirectStandardOutput = true;
            p.StartInfo.FileName = asProcesses[0];
            p.StartInfo.UseShellExecute = false;
            p.Start();
            foreach (var path in asProcesses.Skip(1))
            {
                var p2 = new Process();
                p2.StartInfo.FileName = path;
                p2.StartInfo.RedirectStandardInput = true;
                p2.StartInfo.RedirectStandardOutput = true;
                p2.StartInfo.UseShellExecute = false;
                p.WaitForExit();
                p2.StandardInput.Write(p.StandardOutput.ReadToEnd());
            }
            p.WaitForExit();
            string result = p.StandardOutput.ReadToEnd();
