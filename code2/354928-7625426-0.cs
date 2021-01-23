    private void frmMain_Resize(object sender, EventArgs e)
    {
     if (FormWindowState.Minimized == this.WindowState)
    {
     mynotifyicon.Visible = true;
     mynotifyicon.ShowBalloonTip(500);
     this.Hide();
    }
     else if (FormWindowState.Normal == this.WindowState)
     {
     mynotifyicon.Visible = false;
     }
    }
