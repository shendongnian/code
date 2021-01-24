    public class IgnoreTypeContractResolver : DefaultContractResolver
    {
        protected override JsonProperty CreateProperty(MemberInfo member, MemberSerialization memberSerialization)
        {
            var property = base.CreateProperty(member, memberSerialization);
            if (property.DeclaringType == typeof(PItem) && property.PropertyName == "type")
            {
                property.ShouldSerialize = i => false;
                property.Ignored = true;
            }
            return property;
        }
    }
