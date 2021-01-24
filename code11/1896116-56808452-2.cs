        public void StartExe()
        {
            var proc = System.Diagnostics.Process.Start(strExePath);
            proc.WaitForExit(); // This is not on the UI thread so it will not block the UI thread
            this.Invoke(new Action(() => UpdateGUI(this,"Finished Proc Once!")));
            proc = System.Diagnostics.Process.Start(strExePath);
            proc.WaitForExit(); // This is not on the UI thread so it will not block the UI thread
            this.Invoke(new Action(() => UpdateGUI(this, "Finished Proc Again!")));
            proc = System.Diagnostics.Process.Start(strExePath);
            proc.WaitForExit(); // This is not on the UI thread so it will not block the UI thread
            this.Invoke(new Action(() => UpdateGUI(this, "Finished Proc Once Again!")));
        }
        public void UpdateGUI(Form theGui, string msg) { // This will wil update the GUI when the GUI thread is not busy
            lblGUIUpdate.Text = msg;
        }
        public void MainMeth()
        {
            Thread th = new Thread(StartExe);
            th.Start(); // After this, the GUI thread will not block
        }  
