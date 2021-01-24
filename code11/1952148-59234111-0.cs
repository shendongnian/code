        public static PropertyBuilder HasDefaultValue(
            [NotNull] this PropertyBuilder propertyBuilder,
            [CanBeNull] object value = null)
        {
            Check.NotNull(propertyBuilder, nameof(propertyBuilder));
            propertyBuilder.Metadata.SetDefaultValue(value ?? DBNull.Value);
            return propertyBuilder;
        }
