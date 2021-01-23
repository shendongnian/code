    protected void dg_DeleteCommand(object sender, DataGridCommandEventArgs e)     
    {
             XmlFunctions.Remove(grid selected value);     
    }
    
    public static void Remove(string itemValue) 
    {
       XDocument doc = XDocument.Load("xmlfile.xml");
       doc.Descendants("test")
             .Where(p=>p.Attribute("id") != null 
                       && p.Attribute("id").Value == itemValue)
             .SingleOrDefault().Remove();
    }
