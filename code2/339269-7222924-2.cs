    private void linkLabel1_LinkClicked(object sender, System.Windows.Forms.LinkLabelLinkClickedEventArgs e)
    {
        // Specify that the link was visited.
        this.linkLabel1.LinkVisited = true;
        // Navigate to a URL.
        System.Diagnostics.Process.Start("http://www.microsoft.com");
    }
