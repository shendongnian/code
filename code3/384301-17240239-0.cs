    protected void btnInsert_Click(object sender, EventArgs e)
        {
            System.Xml.XmlDocument myXml = new System.Xml.XmlDocument();
            myXml.Load(Server.MapPath("InsertData.xml"));
            System.Xml.XmlNode xmlNode = myXml.DocumentElement.FirstChild;
            System.Xml.XmlElement xmlElement = myXml.CreateElement("entry");
          
            xmlElement.SetAttribute("Name", Server.HtmlEncode(txtname.Text));
            xmlElement.SetAttribute("Location", Server.HtmlEncode(txtlocation.Text));
            xmlElement.SetAttribute("Email", Server.HtmlEncode(txtemail.Text));
            xmlElement.SetAttribute("Gender", Server.HtmlEncode(ddlgender.SelectedItem.Text));
            myXml.DocumentElement.InsertBefore(xmlElement,xmlNode);
            myXml.Save(Server.MapPath("InsertData.xml"));
            BindData();
            lbldisplay.Text = "Record inserted into XML file successfully";
            txtname.Text = "";
            txtlocation.Text = "";
            txtemail.Text = "";
        }
        private void BindData()
        {
            XmlTextReader xmlReader = new XmlTextReader(Server.MapPath("InsertData.xml"));
            xmlReader.Close();
        }
