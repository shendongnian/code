    public class ExtendedModelMetadataProvider : DataAnnotationsModelMetadataProvider
    {
        protected override ModelMetadata CreateMetadata(IEnumerable<System.Attribute> attributes, Type containerType, Func<object> modelAccessor, Type modelType, string propertyName)
        {
            //Possible Multiple Enumerations on IEnumerable fix
            var attributeList = attributes as IList<System.Attribute> ?? attributes.ToList();
            //Default behavior
            var data = base.CreateMetadata(attributeList, containerType, modelAccessor, modelType, propertyName);
            //Bind DescriptionAttribute
            var description = attributeList.SingleOrDefault(a => typeof(DescriptionAttribute) == a.GetType());
            if (description != null)
            {
                data.Description = ((DescriptionAttribute)description).Description;
            }
            return data;
        }
    }
