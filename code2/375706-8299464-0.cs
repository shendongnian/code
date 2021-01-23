    // Generate parameters
    Dictionary<string, string> signalparams = new Dictionary<string, string>();
    // Add parameters
    foreach (SettingsProperty property in Properties.Settings.Default.Properties)
    {
        if (property.SerializeAs == SettingsSerializeAs.String)
        {
            signalparams.Add(property.Name, Properties.Settings.Default[property.Name].ToString());
        }
        else if (property.SerializeAs == SettingsSerializeAs.Xml)
        {
            // Serialize collection into XML manually
            XmlSerializer serializer = new XmlSerializer(Properties.Settings.Default[property.Name].GetType());
            
            StringBuilder sb = new StringBuilder();
            XmlWriter writer = XmlWriter.Create(sb);
            serializer.Serialize(writer, Properties.Settings.Default[property.Name]);
            writer.Close();
            signalparams.Add(property.Name, sb.ToString());
        }
    }
