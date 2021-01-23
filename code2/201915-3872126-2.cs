    private List<XmlElement> functionA ()
    {
        XmlDocument doc = new XmlDocument();
        List<XmlElement> elementList = new List<XmlElement>();
        XmlElement element;
        string serializedPublishedPage = Serializer.SerializeObject(PublishedPage, typeof(PublishedPage));
        string serializedDeletedPage = Serializer.SerializeObject(DeletedPage, typeof(DeletedPage));
        string serializedMovedPage = Serializer.SerializeObject(MovedPage, typeof(MovedPage));
        doc.LoadXml(serializedDemographic);
        element = doc.DocumentElement;
        elementList.Add(element);
        return elementList;
    }
