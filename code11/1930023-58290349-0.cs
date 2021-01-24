    public class CustomResolver : DefaultContractResolver
    {
        protected override JsonProperty CreateProperty(MemberInfo member, MemberSerialization memberSerialization)
        {
            JsonProperty prop = base.CreateProperty(member, memberSerialization);
            if (prop.DeclaringType == typeof(DataObject) && prop.PropertyName == nameof(DataObject.Data))
            {
                prop.Ignored = true;
            }
            return prop;
        }
    }
