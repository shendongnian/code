    protected void dg_DeleteCommand(object sender, DataGridCommandEventArgs e)     
    {
             var selValue = grid.SelectedValue.ToString();
             XmlFunctions.Remove(selValue);     
    }
    
    public static void Remove(string itemValue) 
    {
       XDocument doc = XDocument.Load("xmlfile.xml");
       doc.Descendants("test")
             .Where(p=>p.Attribute("id") != null 
                       && p.Attribute("id").Value == itemValue)
             .SingleOrDefault().Remove();
    }
