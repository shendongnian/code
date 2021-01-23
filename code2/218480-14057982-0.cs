    private void SetValue(string xmlFilePath, string key, string value)
    {
       try
       {
          XDocument doc = XDocument.Load(xmlFilePath);
          XElement element = doc.Descendants("add").Where(d => d.Attribute("key") != null && d.Attribute("key").Value == key).First();
          element.Attribute("value").Value = value;
          doc.Save(xmlFilePath);
        }
        catch (Exception ex)
        {
          MessageBox.Show(ex.Message);
        }
    }
