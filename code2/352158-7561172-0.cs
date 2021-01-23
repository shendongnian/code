    public List<cApplication> GetAppSettings()
            {
                if (!File.Exists(Config.System.XMLFilePath))
                {
                    WriteXMLFile();
                }
    
                try
                {
                    XDocument data = XDocument.Load(Config.System.XMLFilePath);
    
                    return (from c in data.Descendants("Application")
                            orderby c.Attribute("Name")
                            select new cApplication()
                            {
                                LocalVersion = (c!=null)?c.Element("Version").Value:string.Empty,
                                RemoteVersion = (c!=null)?c.Element("RemoteVersion").Value:string.Empty,
                                DisableApp = (c!=null)?((YesNo)Enum.Parse(typeof(YesNo), c.Element("DisableApplication").Value, true)):YesNo.No,
                                SuspressMessages = (c != null) ? ((YesNo)Enum.Parse(typeof(YesNo), c.Element("SuspressMessage").Value, true)):YesNo.No
                            }).ToList();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    List<cApplication> l = new List<cApplication>().ToList();
                    return l.ToList();
                }
            }
