    using System;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.Web.Mvc;
    public class MyCustomModelMetadataProvider : DataAnnotationsModelMetadataProvider
    {
        protected override ModelMetadata GetMetadataForProperty(Func<object> modelAccessor,
            Type containerType,
            PropertyDescriptor propertyDescriptor)
        {
            var metadata = base.GetMetadataForProperty(modelAccessor, 
                containerType, propertyDescriptor);
            var display = propertyDescriptor.Attributes
                .OfType<DisplayAttribute>().FirstOrDefault();
            if (display != null)
            {
                metadata.DisplayName = TextManager.GetValue(display.Name);
            }
            return metadata;
        }
    }
