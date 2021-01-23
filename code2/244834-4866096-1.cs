    String xml = dtbl.Rows[0]["XMLColumnName"].ToString();
    string filename = System.Web.HttpContext.Current.Server.MapPath("~/yourSample.xml");
    XmlDocument xmlDoc = new XmlDocument();
    XmlTextWriter xmlWriter = new XmlTextWriter(filename, System.Text.Encoding.UTF8);
    xmlWriter.Formatting = Formatting.Indented;
    xmlWriter.WriteProcessingInstruction("xml", "version='1.0' encoding='UTF-8'");
    xmlWriter.WriteRaw(xml);
    xmlWriter.Close();
    xmlWriter.Flush();
