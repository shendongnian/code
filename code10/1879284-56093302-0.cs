    private void btn_YT_Click(object sender, EventArgs e)
    {
        webBrowser1.Navigate(@"https://www.youtube.com/?gl=GB");
        webBrowser1.Visible = true;
        if (ModifierKeys.HasFlag(Keys.Control))
        {
            webBrowser1.Visible = false;
        }
        else
        {
            MessageBox.Show("Fix this issue");
        }
    }// Add This
