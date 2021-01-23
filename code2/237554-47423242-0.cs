    public class CustomContractResolver : DefaultContractResolver
    {
        private readonly JsonMediaTypeFormatter formatter;
        public CustomContractResolver(JsonMediaTypeFormatter formatter)
        {
            this.formatter = formatter;
        }
        public JsonMediaTypeFormatter Formatter
        {
            [DebuggerStepThrough]
            get { return this.formatter; }
        }
        protected override JsonProperty CreateProperty(MemberInfo member, MemberSerialization memberSerialization)
        {
            JsonProperty property = base.CreateProperty(member, memberSerialization);
            this.ConfigureProperty(member, property);
            return property;
        }
        private void ConfigureProperty(MemberInfo member, JsonProperty property)
        {
            if (Attribute.IsDefined(member, typeof(XmlIgnoreAttribute), true))
            {
                property.Ignored = true;
            }            
        }
    }
