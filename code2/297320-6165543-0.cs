      var yourcommand = "<put your command here>";
      var procStart = new System.Diagnostics.ProcessStartInfo("cmd", "/c " + yourcommand);
      procStart.CreateNoWindow = true;
      procStart.RedirectStandardOutput = true;
       procStart.UseShellExecute = false;
       var proc = new System.Diagnostics.Process();
       proc.StartInfo = procStart;
       proc.Start();
       var result = proc.StandardOutput.ReadToEnd();
   
       Console.WriteLine(result);
