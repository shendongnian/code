    [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        static extern bool SetForegroundWindow(IntPtr hWnd);
        Process p;
        //Process p is initialized: p = Process.Start(@"<path\application.exe>");
        Form2 oForm;
     private void transition()
        {
            BackgroundWorker bw = new BackgroundWorker();
            oForm = new Form2();
            bw.DoWork += new DoWorkEventHandler(bw_DoWork);
            bw.RunWorkerCompleted += new RunWorkerCompletedEventHandler(bw_RunWorkerCompleted);
            oForm.Show();
            if (bw.IsBusy != true)
            {
                bw.RunWorkerAsync();
            }
          
        }
        private void bw_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {       
            oForm.closethis();
        }
        private void bw_DoWork(object sender, DoWorkEventArgs e)
        {
            BackgroundWorker worker = sender as BackgroundWorker;
                if ((worker.CancellationPending == true))
                {
                    e.Cancel = true;                   
                }
                else
                {                   
                    SetForegroundWindow(p.MainWindowHandle);
                    p.WaitForInputIdle(3000);
                    System.Threading.Thread.Sleep(500);
                    SendKeys.SendWait("{F11}");    
                    //Sends the application into full screen mode           
                }
            
        }
