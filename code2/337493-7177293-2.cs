    private void Form1_Load(object sender, EventArgs e)
    {
        if (Process.GetProcessesByName(Process.GetCurrentProcess().ProcessName).Length > 1)
        {
            MessageBox.Show("Hey there opening multiple instances of this process is restricted!", "Error",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
            this.Close();
        }
    }
