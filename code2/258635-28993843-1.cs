    protected void Page_Load(object sender, EventArgs e)
    {
        XmlTextReader reader = new XmlTextReader(Server.MapPath("~/XML"));
         
        while(reader.Read())
        {
            switch(reader.NodeType)
            {
                case XmlNodeType.Element:                            
                    var lbl = new  Label();
                    lbl.Text=(reader.Name + " -> " );
                    break;
                case XmlNodeType.Text:                                 
                    Response.Write(reader.Value + "<br />");
                     break;
                case XmlNodeType.EndElement:                        
                     Response.Write("</" + reader.Name + ">");
                     break;
            }
        }
    }
