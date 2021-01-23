        public string ConnString { get; set; }
        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (CBox.SelectedIndex == 0)
            {
                ConnString = getAppSetting("sampleconnectionstring");
            }
            else if (CBox.SelectedIndex == 1)
            {
                ConnString = getAppSetting("sampleconnectionstring1");
            }
            else if (CBox.SelectedIndex == 2)
            {
                ConnString = getAppSetting("sampleconnectionstring2");
            }
            else if (CBox.SelectedIndex == 3)
            {
                ConnString = getAppSetting("sampleconnectionstring3");
            }
        }
        private string getAppSetting(string strKey)
        {
            string strValue = string.Empty;
            XmlReaderSettings settings = new XmlReaderSettings();
            settings.XmlResolver = new XmlXapResolver();
            XmlReader reader = XmlReader.Create("ServiceReferences.ClientConfig");
            reader.MoveToContent();
            while (reader.Read())
            {
                if (reader.NodeType == XmlNodeType.Element && reader.Name == "add")
                {
                    if (reader.HasAttributes)
                    {
                        strValue = reader.GetAttribute("key");
                        if (!string.IsNullOrEmpty(strValue) && strValue == strKey)
                        {
                            strValue = reader.GetAttribute("value");
                            return strValue;
                        }
                    }
                }
            }
            return strValue;
        }
        private void LayoutRoot_Loaded(object sender, RoutedEventArgs e)
        {
            ConnString = getAppSetting("sampleconnectionstring");
            
        }
