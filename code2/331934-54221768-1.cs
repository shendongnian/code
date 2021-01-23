    private static ICollection<LinkedResource> GetLinkedResources()
    {
        var linkedResources = new List<LinkedResource>();
        linkedResources.Add(new LinkedResource(@"imagepath")
        {
            ContentId = "HeaderId",
            TransferEncoding = TransferEncoding.Base64
        });
        linkedResources.Add(new LinkedResource(@"imagepath")
        {
            ContentId = "MapId",
            TransferEncoding = TransferEncoding.Base64
        });
        return linkedResources;
    }
