            string command = System.IO.Path.Combine(Environment.SystemDirectory, "wscript.exe");
            string args1 = ""; //Appropriate arguments
            ProcessStartInfo psInfo = new ProcessStartInfo(command);
            psInfo.Arguments = args1;
            psInfo.Verb = "runas";
            try
            {
                Process p = Process.Start(psInfo);
                p.WaitForExit();
                //return "Try Done";
            }
            catch (Exception e)
            {
                //return e.Message;
            }
