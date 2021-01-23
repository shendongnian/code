    public class IgnorableSerializerContractResolver : DefaultContractResolver
    {
        protected readonly Dictionary<Type, HashSet<string>> Ignores;
        public IgnorableSerializerContractResolver()
        {
            Ignores = new Dictionary<Type, HashSet<string>>();
        }
        /// <summary>
        /// Explicitly ignore the given property(s) for the given type
        /// </summary>
        /// <param name="type"></param>
        /// <param name="propertyName">one or more properties to ignore.  Leave empty to ignore the type entirely.</param>
        public IgnorableSerializerContractResolver Ignore(Type type, params string[] propertyName)
        {
            // start bucket if DNE
            if (!Ignores.ContainsKey(type))
                Ignores[type] = new HashSet<string>();
            foreach (var prop in propertyName)
            {
                Ignores[type].Add(prop);
            }
            return this;
        }
        /// <summary>
        /// Is the given property for the given type ignored?
        /// </summary>
        /// <param name="type"></param>
        /// <param name="propertyName"></param>
        /// <returns></returns>
        public bool IsIgnored(Type type, string propertyName)
        {
            if (!Ignores.ContainsKey(type)) return false;
            // if no properties provided, ignore the type entirely
            return Ignores[type].Count == 0 || Ignores[type].Contains(propertyName);
        }
        /// <summary>
        /// The decision logic goes here
        /// </summary>
        /// <param name="member"></param>
        /// <param name="memberSerialization"></param>
        /// <returns></returns>
        protected override JsonProperty CreateProperty(MemberInfo member, MemberSerialization memberSerialization)
        {
            var property = base.CreateProperty(member, memberSerialization);
            if (IsIgnored(property.PropertyType, property.PropertyName))
            {
                property.ShouldSerialize = instance => false;
            }
            return property;
        }
    }
