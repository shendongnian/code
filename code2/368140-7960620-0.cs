     public class FakeTypeContractResolver : DefaultContractResolver
        {        
            protected override string ResolvePropertyName(string propertyName)
            {
                return propertyName == "_type_" ? "$type" : propertyName;
            }
        }
