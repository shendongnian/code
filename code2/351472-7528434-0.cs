     private void Form_Resize(object sender, EventArgs e)
     {
        if (WindowState == FormWindowState.Minimized)
        {
            this.Hide();
        }
     }
     private void notifyIcon_Click(object sender, EventArgs e)
     {
        this.Show();
        this.WindowState = FormWindowState.Normal;
    }
