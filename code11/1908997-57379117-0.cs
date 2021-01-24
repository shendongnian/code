    foreach (DataRow dr in ds.Tables[0].Rows.Cast<DataRow>().Skip(1))
    {
        writer.WriteStartElement("trades");
        writer.WriteElementString("time", "%%__TIME__%%");
        writer.WriteEndElement();
    }
    
    string time = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");    
    
    string xml = // here serialize the xml from writer
    
    IO.File.WriteAllText(filename,xml.Replace("%%__TIME__%%",time);
