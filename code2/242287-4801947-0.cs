            try
            {
                Process p = StartProcess(ExecutableFileName);
                p.Start();
                p.WaitForExit();
            }
            catch
            {
                Log("The program failed to execute.");
            }
