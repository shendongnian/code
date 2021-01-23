    public static Dictionary<int, string> GetAll(CRMBase conn, string entityName, string attributeName)
    {
         OptionMetadataCollection result = RetrieveOptionSetMetaDataCollection(conn, entityName,           attributeName);
         return result.Where(r => r.Value.HasValue).ToDictionary(r => r.Value.Value, r => r.Label.UserLocalizedLabel.Label);
    }
    
    // Method to retrieve OptionSet Options Metadadata collection.
    private static OptionMetadataCollection RetrieveOptionSetMetaDataCollection(CRMBase conn, string prmEntityName, string prmAttributeName)
    {
         RetrieveEntityRequest retrieveEntityRequest = new RetrieveEntityRequest();
    
         retrieveEntityRequest.LogicalName = prmEntityName;
    
         retrieveEntityRequest.EntityFilters = Microsoft.Xrm.Sdk.Metadata.EntityFilters.Attributes;
    
         RetrieveEntityResponse retrieveEntityResponse = (RetrieveEntityResponse)conn._orgContext.Execute(retrieveEntityRequest);
    
         return (from AttributeMetadata in retrieveEntityResponse.EntityMetadata.Attributes where 
         (AttributeMetadata.AttributeType == AttributeTypeCode.Picklist & AttributeMetadata.LogicalName == prmAttributeName) 
         select ((PicklistAttributeMetadata)AttributeMetadata).OptionSet.Options).FirstOrDefault();
    }
