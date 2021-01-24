       Process sql = new Process();   
       sql.StartInfo.CreateNoWindow = true;
       sql.StartInfo.UseShellExecute = true;
       sql.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
       sql.StartInfo.FileName = @"sqlcmd.exe";
       sql.StartInfo.Arguments = param;
            
       sql.EnableRaisingEvents = true;
       sql.Exited += new EventHandler(sql_Exited);
       sql.Start();
