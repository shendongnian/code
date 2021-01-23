        protected void Button1_Click(object sender, EventArgs e)
        {
        System.Xml.Linq.XDocument mydoc;
        if (System.IO.File.Exists(MapPath("myxmlfile.xml")))
            mydoc = System.Xml.Linq.XDocument.Load(MapPath("myxmlfile.xml"));
        else
            mydoc = new System.Xml.Linq.XDocument(new System.Xml.Linq.XDeclaration("1.0",  "UTF-8", "yes"));
        //mydoc.Root.Add(new System.Xml.Linq.XElement("comment", TextBox1.Text));
        System.Xml.Linq.XElement ele = new System.Xml.Linq.XElement("comment", TextBox1.Text);
        mydoc.Root.Add(ele);
        mydoc.Save(MapPath("myxmlfile.xml"), System.Xml.Linq.SaveOptions.None);
        }
