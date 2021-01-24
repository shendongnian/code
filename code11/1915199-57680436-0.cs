    class ValueTypePropertiesRequiredResolver : DefaultContractResolver
    {
        protected override JsonProperty CreateProperty(MemberInfo member, MemberSerialization memberSerialization)
        {
            JsonProperty prop = base.CreateProperty(member, memberSerialization);
            if (prop.PropertyType.IsValueType)
            {
                prop.Required = Required.Always;
            }
            return prop;
        }
    }
