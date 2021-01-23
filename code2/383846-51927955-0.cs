    static XmlDocument xdoc = new XmlDocument(); //static; since i had to access this file someother place too
    protected void CreateXmlFile(DataSet ds) 
        {
          //ds contains sales details in this code; i.e list of products along with quantity and unit
          //You may change attribute acc to your needs ; i.e employee details in the below code
            
            string salemastid = lbl_salemastid.Text;
            int i = 0, j=0;
            String str = "salemastid:" + salemastid;
            DataTable dt = ds.Tables[0];
            string xml = "<Orders>" ;
             while (j < dt.Rows.Count)
             {
                 int slno = j + 1;
                 string sl = slno.ToString();
                 xml += "<SlNo>" + sl +"</SlNo>" +
                           "<PdtName>" + dt.Rows[j][0].ToString() + "</PdtName>" +
                           "<Unit>" + dt.Rows[j][1].ToString() + "</Unit>" +
                           "<Qty>" + dt.Rows[j][2].ToString() + "</Qty>";
                 j++;
             }
             xml += "</Orders>";
              
             xdoc.LoadXml(xml);
             //Here the xml is prepared and loaded in xml DOM.
             xdoc.Save(Server.MapPath("Newsales.xml"));
             //You may also use some other names instead of 'Newsales.xml'
             //to get a downloadable file use the below code
             System.IO.MemoryStream stream = new System.IO.MemoryStream();
                    XmlTextWriter xwriter = new XmlTextWriter(stream, System.Text.Encoding.UTF8);
                    
                    xdoc.WriteTo(xwriter);
                    xwriter.Flush();
                    Response.Clear();
                    Encoding.UTF8.GetString(stream.ToArray());
                    byte[] byteArray = stream.ToArray();
                    Response.AppendHeader("Content-Disposition", "filename=OrderRequest.xml");
                    Response.AppendHeader("Content-Length", byteArray.Length.ToString());
                    Response.ContentType = "application/octet-stream";
                    Response.BinaryWrite(byteArray);
                    xwriter.Close();
                    stream.Close();
            } 
