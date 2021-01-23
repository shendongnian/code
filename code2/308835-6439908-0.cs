    private void findToolStripMenuItem_Click(object sender, EventArgs e)
    {
        if(webBrowser1.Visible)
        {
              webBrowser1.Select();
              SendKeys.Send("^f");
        }
    }
