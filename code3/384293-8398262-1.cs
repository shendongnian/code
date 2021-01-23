    protected void Button1_Click(object sender, EventArgs e)
    {
        string file = MapPath("~/comments.xml");
    
        XDocument doc;
            
        //Verify whether a file is exists or not
        if (!System.IO.File.Exists(file))
        {
            doc = new XDocument(new XDeclaration("1.0", "UTF-8", "yes"),
                new System.Xml.Linq.XElement("comments"));
        }
        else
        {
            doc = XDocument.Load(file);
        }
    
        XElement ele = new XElement("comment",TextBox1.Text);
        doc.Root.Add(ele);
        doc.Save(file);
    }
