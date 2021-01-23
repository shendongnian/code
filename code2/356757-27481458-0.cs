    public class LocalizedModelMetadataProvider : DataAnnotationsModelMetadataProvider
    {
        protected override ModelMetadata CreateMetadata(IEnumerable<Attribute> attributes, Type containerType,
                                                        Func<object> modelAccessor, Type modelType, string propertyName)
        {
            
            var metadata = base.CreateMetadata(attributes, containerType, modelAccessor, modelType, propertyName);
            if (containerType == null || propertyName == null)
                return metadata;
            if (metadata.DisplayName == null)
                metadata.DisplayName = ResourceManager.Current.GetLocalizedAttribute(containerType, propertyName);
            if (metadata.Watermark == null)
                metadata.Watermark = ResourceManager.Current.GetLocalizedAttribute(containerType, propertyName, "Watermark");
            if (metadata.Description == null)
                metadata.Description = ResourceManager.Current.GetLocalizedAttribute(containerType, propertyName, "Description");
            if (metadata.NullDisplayText == null)
                metadata.NullDisplayText = ResourceManager.Current.GetLocalizedAttribute(containerType, propertyName, "NullDisplayText");
            if (metadata.ShortDisplayName == null)
                metadata.ShortDisplayName = ResourceManager.Current.GetLocalizedAttribute(containerType, propertyName, "ShortDisplayName");
            return metadata;
        }
    }
    public class LocalizedModelValidatorProvider : DataAnnotationsModelValidatorProvider
    {
        protected override IEnumerable<ModelValidator> GetValidators(ModelMetadata metadata, ControllerContext context, IEnumerable<Attribute> attributes)
        {
            foreach (var attribute in attributes.OfType<ValidationAttribute>())
                attribute.ErrorMessage = ResourceManager.Current.GetValidationMessage(attribute);
            return base.GetValidators(metadata, context, attributes);
        }
    }
