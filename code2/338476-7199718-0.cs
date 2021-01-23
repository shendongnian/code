    private void Form1_FormClosing(object sender, EventArgs e)
    {
      MailSystem.Properties.Settings.Default.splitterLocation = splitter1.Location;
      MailSystem.Properties.Settings.Default.Save();
    }
