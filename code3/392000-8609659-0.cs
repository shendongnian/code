    public IDictionary<int?, string> LoadFromCRM(string entityName, string logicalName)
    {
        var request = new RetrieveAttributeRequest();
        request.EntityLogicalName = entityName;
        request.LogicalName = logicalName;
        var response = (RetrieveAttributeResponse)lService.Execute(request);
        var picklist = (PicklistAttributeMetadata)response.AttributeMetadata;
    
        return picklist.OptionSet.Options.ToDictionary(o => o.Value, o => o.Label.UserLocalizedLabel.Label.ToString());
    }
    // Usage
    var businessUnits = LoadFromCRM("opportunity", "new_businessunit");
    var marketSegment = LoadFromCRM("opportunity", "new_sourcepick");
