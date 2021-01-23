    private void linkLabel1_LinkClicked(object sender,System.Windows.Forms.LinkLabelLinkClickedEventArgs e)
    {
     System.Diagnostics.Process proc = new System.Diagnostics.Process();
        proc.StartInfo.FileName = "mailto:someone@somewhere.com?subject=hello&body=love my body";
        proc.Start();
    }
