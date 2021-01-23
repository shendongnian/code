                System.Diagnostics.Process proc;
    
                cmd = @"strCmdLine = "/C xxxxx xxxx" + args[0] + i.ToString();
    
                proc = new System.Diagnostics.Process();
                proc.EnableRaisingEvents = false;
                proc.StartInfo.FileName = "cmd";
                proc.StartInfo.Arguments = cmd;
                proc.Start();
