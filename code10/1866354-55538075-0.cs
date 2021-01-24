      public void Btn_Ping_Click_1(object sender, EventArgs e)
      {
         if (Btn_Ping.Text == "Ping")
         {
            _cts = new CancellationTokenSource();
            Btn_Ping.Text = "Stop Ping";
            var task = new Task(() => task1(cts.Token));
            task.Start();
         }
         else if (Btn_Ping.Text == "Stop Ping")
         {
            Btn_Ping.Text = "Ping";
            _cts.Cancel();
         }
      }
      public void task1(CancellationToken ct)
      {
         try
         {
            string command = "/c ping " + Txt_Main.Text.Trim() + " -t";
            var procStartInfo = new ProcessStartInfo("CMD", command);
            var proc = new Process {StartInfo = procStartInfo};
            proc.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
            proc.StartInfo.RedirectStandardOutput = true;
            proc.StartInfo.RedirectStandardInput = true;
            proc.StartInfo.RedirectStandardError = true;
            proc.StartInfo.UseShellExecute = false;
            proc.StartInfo.CreateNoWindow = true;
            proc.OutputDataReceived += new DataReceivedEventHandler(proc_OutPutDataRecieved);
            proc.Start();
            proc.BeginOutputReadLine();
            while (!proc.WaitForExit(250))
            {
               if (ct.IsCancellationRequested)
               {
                  proc.Kill();
                  return;
               }
            }
         }
         catch (Exception)
         {
            //If an error occurs within the try block, it will be handled here
         }
      }
