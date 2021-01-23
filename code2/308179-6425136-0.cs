        private void button1_Click(object sender, EventArgs e) {
            button1.Enabled = false;
            // Save data to database
            //...
            System.Threading.Thread.Sleep(2000);
            Application.DoEvents();   // Empty the message queue
            if (!button1.IsDisposed) button1.Enabled = true;
        }
