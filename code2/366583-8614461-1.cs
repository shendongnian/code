    string xml = "<?xml version='1.0' encoding='UTF-8'?><foo><bar></bar></foo>";
    XmlDocument document = new XmlDocument();
    document.LoadXml(xml);
    
    MemoryStream memStream = new MemoryStream();
    XmlWriterSettings settings = new XmlWriterSettings();
    settings.Encoding = Encoding.UTF8;
    settings.Indent = true;
    using (XmlWriter writer = XmlWriter.Create(memStream, settings))
    {
        document.Save(writer);
    }
    memStream.Flush();
         
    string formattedXml = Encoding.UTF8.GetString(memStream.ToArray());
    
    // strip UTF-8 BOM if required. Good for display purposes, can leave as such
    // for normal processing.
    string preAmble = Encoding.UTF8.GetString(Encoding.UTF8.GetPreamble());
    if (formattedXml.StartsWith(preAmble)) 
    {
        formattedXml = formattedXml.Remove(0, preAmble.Length);
        Console.WriteLine(formattedXml);
    }
