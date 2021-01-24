    public class CustomContractResolver : DefaultContractResolver
    {
        const string InternalSuffix = "Internal";
        protected override JsonProperty CreateProperty(MemberInfo member, MemberSerialization memberSerialization)
        {
            var property = member as PropertyInfo;
            var jProperty = base.CreateProperty(member, memberSerialization);
            if (property != null && jProperty != null && memberSerialization != MemberSerialization.Fields && !jProperty.HasMemberAttribute)
            {
                var replacementName = jProperty.UnderlyingName + InternalSuffix;
                var replacementProperty = jProperty.DeclaringType.GetProperty(replacementName, BindingFlags.Instance | BindingFlags.NonPublic);
                if (replacementProperty != null
                    // Here you could add additional restrictions, such as
                    && property.PropertyType.IsGenericType && typeof(IReadOnlyList<>).IsAssignableFrom(property.PropertyType.GetGenericTypeDefinition())
                    && replacementProperty.PropertyType.IsGenericType && typeof(List<>).IsAssignableFrom(replacementProperty.PropertyType.GetGenericTypeDefinition())
					&& replacementProperty.PropertyType.GetGenericArguments().SequenceEqual(property.PropertyType.GetGenericArguments())
                    && replacementProperty.GetGetMethod(true) != null && replacementProperty.GetSetMethod(true) != null
                    )
                {
                    var replacementJProperty = base.CreateProperty(replacementProperty, memberSerialization);
                    replacementJProperty.PropertyName = jProperty.PropertyName;
                    if (!replacementJProperty.Readable && replacementProperty.GetGetMethod(true) != null)
                        replacementJProperty.Readable = true;
                    if (!replacementJProperty.Writable && replacementProperty.GetSetMethod(true) != null)
                        replacementJProperty.Writable = true;
                    return replacementJProperty;
                }
            }
            return jProperty;
        }
    }
