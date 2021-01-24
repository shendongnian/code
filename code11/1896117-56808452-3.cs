        static readonly object _object = new object();
        public int iProcCount = 0;
        public void StartExe()
        {
            System.Diagnostics.Process proc;
            lock (_object) // Because WaitForExit is inside the lock all other 
                           // instances of this thread must wait before the 
                           // previous thread has finished
            {
                proc = System.Diagnostics.Process.Start(strExePath);
                proc.WaitForExit(); // This is not on the UI thread so it will not block the UI thread
            }
            this.Invoke(new Action(() => UpdateGUI(this, "Finished Proc " + iProcCount)));
            iProcCount++;
        }
        public void UpdateGUI(Form theGui, string msg)
        { // This will wil update the GUI when the GUI thread is not busy
            lblGUIUpdate.Text = msg;
        }
        private void Button_Click(object sender, EventArgs e)
        {
            Thread th = new Thread(StartExe);
            th.Start(); // After this, the GUI thread will not block
        }  
