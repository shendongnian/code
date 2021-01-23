    public class UniquePropertyConvention : AttributePropertyConvention<UniqueAttribute>
    {
        protected override void Apply(UniqueAttribute attribute, IPropertyInstance instance)
        {
            instance.UniqueKey(attribute.GetKey());
        }
    }
