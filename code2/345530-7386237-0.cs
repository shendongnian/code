            {
 
               xmlDoc = XDocument.Load(TextBox1.Text);
            }
            catch (Exception ex)
            {
                Debug.WriteLine("  " + ex.ToString());
            }
            if (null == xmlDoc)
            {
                // Load from Isolated Storage failed so load from default settings in XAP file
                xmlDoc = XDocument.Load("Default.xml", LoadOptions.None);
            }
            xmlDoc.Element("").Add(new XElement("username"));
            xmlDoc.Save(strmSettings);
            strmSettings.Close();
