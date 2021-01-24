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
            // See if there is a [TranslatedFieldName] attribute applied to the property 
            // for the requested language
            var att = prop.AttributeProvider.GetAttributes(true)
                                            .OfType<TranslatedFieldNameAttribute>()
                                            .FirstOrDefault(a => a.Lang == Language);
            // if so, change the property name to the one from the attribute
            if (att != null)
            {
                prop.PropertyName = att.Name;
            }
            return prop;
        }
    }
