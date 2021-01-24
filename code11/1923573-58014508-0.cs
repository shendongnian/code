    public class MultiLangResolver : DefaultContractResolver
    {
        public Language Language { get; set; }
        public MultiLangResolver(Language lang)
        {
            Language = lang;
        }
        protected override JsonProperty CreateProperty(MemberInfo member, MemberSerialization memberSerialization)
        {
            JsonProperty prop = base.CreateProperty(member, memberSerialization);
            var att = prop.AttributeProvider.GetAttributes(true)
                                            .OfType<TranslatedFieldNameAttribute>()
                                            .FirstOrDefault(a => a.Lang == Language);
            if (att != null)
            {
                prop.PropertyName = att.Name;
            }
            return prop;
        }
    }
