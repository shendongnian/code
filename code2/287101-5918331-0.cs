        private void button1_Click(object sender, EventArgs e) {
            var prc = new System.Diagnostics.Process();
            prc.StartInfo.FileName = "notepad.exe";
            prc.EnableRaisingEvents = true;
            prc.SynchronizingObject = this;
            prc.Exited += delegate { 
                this.WindowState = FormWindowState.Normal;
                prc.Dispose();
            };
            prc.Start();
            this.WindowState = FormWindowState.Minimized;
        }
