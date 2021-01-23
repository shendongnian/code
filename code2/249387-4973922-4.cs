    public class DisplayMetaDataProvider : DataAnnotationsModelMetadataProvider
    {
        protected override ModelMetadata CreateMetadata(
            IEnumerable<Attribute> attributes, 
            Type containerType,
            Func<object> modelAccessor, 
            Type modelType, 
            string propertyName
        )
        {
            var metadata = base.CreateMetadata(attributes, containerType, modelAccessor, modelType, propertyName);
            var displayAttribute = attributes.OfType<DisplayAttribute>().FirstOrDefault();
            if (displayAttribute != null)
            {
                metadata.Description = displayAttribute.Description;
                metadata.DisplayName = displayAttribute.Name;
            }
            return metadata;
        }
    }
