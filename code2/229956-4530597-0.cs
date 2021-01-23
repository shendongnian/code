    protected void dg_DeleteCommand(object sender, DataGridCommandEventArgs e)     
    {
            int row = dataGridView1.SelectedCells[relatedindex].RowIndex;
            int col = dataGridView1.SelectedCells[relatedindex].ColumnIndex;
            var valueToRemove = dataGridView1[i,j].Value.ToString();
             XmlFunctions.Remove(index);     
    }
    
    public static void Remove(string itemValue) 
    {
       XDocument doc = XDocument.Load("xmlfile.xml");
       doc.Descendants("test")
             .Where(p=>p.Attribute("id") != null 
                       && p.Attribute("id").Value == itemValue)
             .SingleOrDefault().Remove();
    }
