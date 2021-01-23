    public class MyModelMetadataProvider : DataAnnotationsModelMetadataProvider
    {
        public override ModelMetadata GetMetadataForProperty(Func<object> modelAccessor, Type containerType, string propertyName)
        {
            var result = base.GetMetadataForProperty(modelAccessor, containerType, propertyName);
            if (result.DisplayName.IsEmpty()) result.DisplayName = propertyName.InflectTo().Titleized;
            return result;
        }
    }
