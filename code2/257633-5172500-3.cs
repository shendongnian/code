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
                { //*
                    int i = 0;
                    while (!p.HasExited && i < maxWaits)
                    {
                        p2.StandardInput.Write(p.StandardOutput.ReadToEnd()); //Redirect IO. This line means that the second process can start clculations if the first is long-running and writes it's output progressively.
                        Thread.Sleep(delay);
                        i++;
                    }
                }
                //**
                p2.StandardInput.Write(p.StandardOutput.ReadToEnd()); //Redirect last output from p.
                { //*
                    //Kill process if still running:
                    if (!p.HasExited)
                    {
                        try { p.Kill(); }
                        catch { }
                    }
                }
            }
            { //*
                int i = 0;
                while (!p.HasExited && i < maxWaits)
                {
                    Thread.Sleep(delay);
                    i++;
                }
            }
            //**
            string result = p.StandardOutput.ReadToEnd();
            { //*
                if (!p.HasExited)
                {
                    try { p.Kill(); }
                    catch { }
                }
            }
