    var nsManager = new XmlNamespaceManager(new NameTable());
    //register mapping of prefix to namespace uri 
    nsManager.AddNamespace("m", "http://schemas.microsoft.com/ado/2007/08/dataservices/metadata");
    nsManager.AddNamespace("d", "http://schemas.microsoft.com/ado/2007/08/dataservices");
    
    StringBuilder csv = new StringBuilder();
    using (var p = ChoXmlReader.LoadText(xml)
            .WithXPath("//entry/content/m:properties")
            .WithXmlNamespaceManager(nsManager)
            .WithField("Guid", xPath: "d:Guid")
            .WithField("ProcessType", xPath: "d:ProcessType")
            .WithField("Description", xPath: "d:Description")
        )
    {
        using (var w = new ChoCSVWriter(csv)
            .WithFirstLineHeader()
            )
            w.Write(p);
    }
    
    Console.WriteLine(csv);
