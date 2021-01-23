        private void button1_Click(object sender, EventArgs e) {
            var prc = new Process();
            prc.EnableRaisingEvents = true;
            prc.Exited += processExited;
            prc.StartInfo = new ProcessStartInfo("notepad.exe");
            prc.Start();
            this.Hide();
        }
        private void processExited(object sender, EventArgs e) {
            this.BeginInvoke(new Action(() => {
                this.Show();
                this.BringToFront();
            }));
        }
