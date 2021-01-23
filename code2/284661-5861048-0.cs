    private void LinkClick(object sender, System.EventArgs e)
    {
        LinkLabel ll = (LinkLabel)sender;
        System.Diagnostics.Process.Start(ll.Text);
    }
