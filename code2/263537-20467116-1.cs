    if (Convert.ToInt32(txtPortNumber.Text.Trim()) <= 65535)
    {
    
        System.Configuration.Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
        System.Net.Configuration.MailSettingsSectionGroup mailSection = config.GetSectionGroup("system.net/mailSettings") as System.Net.Configuration.MailSettingsSectionGroup;
        mailSection.Smtp.From = txtFrom.Text.Trim();
        mailSection.Smtp.Network.Host = txtFrom.Text.Trim();
        mailSection.Smtp.Network.UserName = txtFrom.Text.Trim();
        mailSection.Smtp.Network.Password = txtPassword.Text.Trim();
        mailSection.Smtp.Network.EnableSsl = chkEnableSSL.Checked;
        mailSection.Smtp.Network.Port = Convert.ToInt32(txtPortNumber.Text.Trim());
        config.Save(ConfigurationSaveMode.Modified);
        MessageBox.Show("Your mail setting has been saved successfully.");
        Application.Restart();
    }
    else
    {
        MessageBox.Show("Port number is not valid, please enter port number between the 0 to 65535.");
    }
