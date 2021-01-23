    private void btnLogIn_Click(object sender, EventArgs e)
        {
			if (checkBox_Remember.Checked)
                    {
                        UpdateAppSettings_("Remember", "1");
                        UpdateAppSettings_("UserName", User.UserName);
                        UpdateAppSettings_("Password", password);
                    }
		}
	private void UpdateAppSettings_(string KeyName, string KeyValue)
        {
            XmlDocument XmlDoc = new XmlDocument();
            XmlDoc.Load(AppDomain.CurrentDomain.SetupInformation.ConfigurationFile);
            foreach (XmlElement xElement in XmlDoc.DocumentElement)
            {
                if (xElement.Name == "appSettings")
                {
                    foreach (XmlNode xNode in xElement.ChildNodes)
                    {
                        if (xNode.Attributes[0].Value == KeyName)
                        {
                            xNode.Attributes[1].Value = KeyValue;
                        }
                    }
                }
            }
            XmlDoc.Save(AppDomain.CurrentDomain.SetupInformation.ConfigurationFile);
        }
