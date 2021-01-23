    public class DerivedTypeFilterContractResolver<T> : DefaultContractResolver
    {
        protected override JsonProperty CreateProperty(MemberInfo member, MemberSerialization memberSerialization)
        {
            JsonProperty property = base.CreateProperty(member, memberSerialization);
            if (property.DeclaringType == typeof (T))
            {
                property.ShouldSerialize =
                    instance => false;
            }
            return property;
        }
