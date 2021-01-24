    using System;
    using System.Web.Mvc;
    public class MyCustomModelMetadataProvider : DataAnnotationsModelMetadataProvider
    {
        public override ModelMetadata GetMetadataForProperty(Func<object> modelAccessor, Type containerType, string propertyName)
        {
            var metadata = base.GetMetadataForProperty(modelAccessor, containerType, propertyName);
            metadata.DisplayName = "Something else";
            return metadata;
        }
    } 
