    public static string GetPublisher()
    {
        XDocument xDocument;
        using (MemoryStream memoryStream = new MemoryStream(AppDomain.CurrentDomain.ActivationContext.DeploymentManifestBytes))
        using (XmlTextReader xmlTextReader = new XmlTextReader(memoryStream))
        {
            xDocument = XDocument.Load(xmlTextReader);
        }
        var description = xDocument.Root.Elements().Where(e => e.Name.LocalName == "description").First();
        var publisher = description.Attributes().Where(a => a.Name.LocalName == "publisher").First();
        return publisher.Value;
    }
