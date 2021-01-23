    public class MyMetadataProvider : DataAnnotationsModelMetadataProvider
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
            var displayFor = attributes.OfType<DisplayForAttribute>().FirstOrDefault();
            if (displayFor != null)
            {
                metadata.AdditionalValues.Add("RequiredRole", displayFor.Role);
            }
            return metadata;
        }
    }
