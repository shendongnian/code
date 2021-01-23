    public static class DataNodeExtensions
       {
          public static string FetchByAttribute(this DataNode d, string Attribute)
          {
             string AttributeValue = d
                             .Codes[Attribute]
                             .Attributes
                             .Single(x => x.EqualsCodeIndex(parentAttribute.CodeIndex))
                             .Value.Trim();
       
                return AttributeValue
    
          }
       }
