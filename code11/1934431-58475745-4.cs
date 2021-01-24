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
				// Check for replacement property.
                var replacementProperty = jProperty.DeclaringType.GetProperty(replacementName, BindingFlags.Instance | BindingFlags.NonPublic);
                if (replacementProperty != null
                    && replacementProperty.GetGetMethod(true) != null && replacementProperty.GetSetMethod(true) != null
                    && ReplacementTypeCompatible(property, replacementProperty.PropertyType)
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
				// Check for replacement field.
                var replacementField = jProperty.DeclaringType.GetField(replacementName, BindingFlags.Instance | BindingFlags.NonPublic);
                if (replacementField != null
                    && ReplacementTypeCompatible(property, replacementField.FieldType)
                    )
                {
                    var replacementJProperty = base.CreateProperty(replacementField, memberSerialization);
                    replacementJProperty.PropertyName = jProperty.PropertyName;
                    replacementJProperty.Readable = true;
                    replacementJProperty.Writable = true;
                    return replacementJProperty;
                }
            }
            return jProperty;
        }
        static bool ReplacementTypeCompatible(PropertyInfo property, Type replacementType)
        {
            // Add here whatever restrictions you need
            if (property.PropertyType.IsGenericType && typeof(IReadOnlyList<>).IsAssignableFrom(property.PropertyType.GetGenericTypeDefinition())
                && replacementType.IsGenericType && typeof(List<>).IsAssignableFrom(replacementType.GetGenericTypeDefinition())
                && replacementType.GetGenericArguments().SequenceEqual(property.PropertyType.GetGenericArguments()))
                return true;
            return false;
        }
    }
