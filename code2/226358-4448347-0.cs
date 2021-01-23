private Dictionary<string, Control> GetControlDictionary(string xmlFilePath)
{
    Dictionary<string, Control> controlsDictionary = new Dictionary<string, Control>();
    Assembly assembly = Assembly.GetAssembly(typeof(System.Windows.Forms.Form));
    
    using (XmlReader xmlReader = XmlReader.Create(xmlFilePath))
    {
        XmlDocument xmlDocument = new XmlDocument();
        xmlDocument.Load(xmlReader);
        XmlNodeList xmlNodesList = xmlDocument.SelectNodes("//Object");
                        
        foreach (XmlNode xmlNode in xmlNodesList)
        {
            if (xmlNode.Attributes.Count > 0)
            {                        
                string typeName = xmlNode.Attributes["type"].Value;
                string objectName = xmlNode.Attributes["name"].Value;
                Type controlType = assembly.GetType(typeName);
                if (controlType != null)
                {
                    object controlObject = Activator.CreateInstance(controlType);
                    if (controlObject is Control)
                    {
                        Control control = controlObject as Control;
                        control.Name = objectName;
                        controlsDictionary.Add(objectName, control);
                        foreach (XmlNode childNode in xmlNode.ChildNodes)
                        {
                            if (string.Equals("Property", childNode.Name))
                            {
                                string propertyName = childNode.Attributes["name"].Value;
                                string propertyValue = childNode.InnerText;
                                PropertyInfo propertyInfo = controlType.GetProperty(propertyName);
                                if (propertyInfo != null)
                                {
                                    if(propertyInfo.PropertyType == typeof(System.Drawing.Size))
                                    {
                                        string width = propertyValue.Split(new char[] {','})[0];
                                        string height = propertyValue.Split(new char[] {','})[1];
                                        System.Drawing.Size size = new Size(Convert.ToInt32(width), Convert.ToInt32(height));
                                        propertyInfo.SetValue(control, size, null);
                                    }
                                    else if(propertyInfo.PropertyType == typeof(System.Drawing.Point))
                                    {
                                        string x = propertyValue.Split(new char[] { ',' })[0];
                                        string y = propertyValue.Split(new char[] { ',' })[0];
                                        System.Drawing.Point point = new Point(Convert.ToInt32(x), Convert.ToInt32(y));
                                        propertyInfo.SetValue(control, point, null);
                                    }
                                    else if (propertyInfo.PropertyType == typeof(string))
                                    {
                                        propertyInfo.SetValue(control, propertyValue, null);
                                    }
                                }
                            }
                        }
                    }                            
                }
            }
        }
    }
    return controlsDictionary;
}
</pre>
