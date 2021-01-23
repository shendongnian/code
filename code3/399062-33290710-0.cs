    public class CustomDataContractResolver : DefaultContractResolver
    {
      public static readonly CustomDataContractResolver Instance = new CustomDataContractResolver ();
    
      protected override JsonProperty CreateProperty(MemberInfo member, MemberSerialization memberSerialization)
      {
        var property = base.CreateProperty(member, memberSerialization);
        if (property.DeclaringType == typeof(MyCustomObject))
        {
          if (property.PropertyName.Equals("LongPropertyName", StringComparison.OrdinalIgnoreCase))
          {
            property.PropertyName = "Short";
          }
        }
        return property;
      }
    }
