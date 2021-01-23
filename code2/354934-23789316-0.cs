    private void Form1_Resize(object sender, EventArgs e)
    {
         if (FormWindowState.Minimized == this.WindowState)
         {
              notifyIcon1.Visible = true;
              notifyIcon1.ShowBalloonTip(500);
              this.Hide();    
         }
         else if (FormWindowState.Normal == this.WindowState)
         {
              notifyIcon1.Visible = false;
         }
    }
    
    private void notifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e)
    {
         this.Show();
         this.WindowState = FormWindowState.Normal;
    }
