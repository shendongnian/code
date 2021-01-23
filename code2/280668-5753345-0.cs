    try
    {            
        XmlDocument xml = new XmlDocument();
        xml.Load("allomasok.xml");
        XmlNodeList xnList = xml.SelectNodes("/radiok/allomas");
        ToolStripMenuItem mi;
        int i;
        foreach (XmlNode xn in xnList)
        {
           string radioNEV = xn["neve"].InnerText;
           string radioURL = xn["url"].InnerText;
           mi = new ToolStripMenuItem();
           mi.Name = "mentett" + i++.ToString();
           mi.Tag = radioURL;
           mi.Text = radioNEV;
           mi.Click += new EventHandler(MenuItemClickHandler);
           sajátokToolStripMenuItem.DropDownItems.Add(mi);
        }
    }
    catch
    {
       MessageBox.Show("Hiba", "NetRadioPlayer");
    }
    finally
    {
        MessageBox.Show("Ennyi mentett állomás van: " + mennyi);
    }
