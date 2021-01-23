    public static class DataTreeExtensions
       {
          public static string FetchByAttribute(this DataTree d, string Attribute)
          {
             string AttributeValue = d
                             .Codes[Attribute]
                             .Attributes
                             .Single(x => x.EqualsCodeIndex(parentAttribute.CodeIndex))
                             .Value.Trim();
       
                return AttributeValue
    
          }
       }
