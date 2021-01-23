    SPContentTypeCollection contentTypes = myList.ContentTypes;
    List<object> values = new List<object>();
    List<SPContentTypeId> blackList = new List<SPContentTypeId>()
    {
        SPBuiltInContentTypeId.System,
        SPBuiltInContentTypeId.Item,
    };
    var goodContentTypes = contentTypes.Where(c => !blackList.Contains(c.Id));
    foreach (SPContentType contentType in goodContentTypes)
    {
        foreach (SPField field in contentType.Fields)
        {
            // Do your stuff with this column e.g. Get value from item
            values.Add(myListItem[field.InternalName]);
        }
    }
