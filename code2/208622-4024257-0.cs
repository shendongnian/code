    protected void ButtonLoadGridView_Click(object sender, EventArgs e)
    {
        XDocument xmlDoc = XDocument.Load(@"f:\queues.xml");
        var q = from c in xmlDoc.Root.Descendants("Queue")
                select new
                {
                    QueueNumber = c.Element("Number").Value,
                    QueueName = c.Element("Name").Value,
                    QueuePCC = c.Element("QueueTag").Value
                };
        dataGridView1.DataSource = q.ToList();
        Session.Add("xmlDoc",xmlDoc);        
    }
    public void dataGridView1_RowDeleting(Object sender, GridViewDeleteEventArgs e)
    {
        // get some node information:
        int rowIndex = e.RowIndex;            
        string someNodeInfo = dataGridView1.Rows[rowIndex].Cells[0].Text;            
        
        // then edit xml :
        XmlDocument xmlDoc = (XmlDocument) Session["xmlDoc"];
        xmlDoc.ChildNodes.Item(rowIndex).RemoveAll();
        Session.Add("xmlDoc", xmlDoc);
    }
    protected void ButtonSave_Click(object sender, EventArgs e)
    {
        XmlDocument xmlDoc = (XmlDocument)Session["xmlDoc"];
        xmlDoc.Save(@"f:\queues2.xml");
    }
