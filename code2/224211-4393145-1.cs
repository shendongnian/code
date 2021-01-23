        private void button1_Click(object sender, EventArgs e) {
            button1.Enabled = false;
            System.Threading.Thread.Sleep(1000);
            Application.DoEvents();
            if (!button1.IsDisposed) button1.Enabled = true;
        }
