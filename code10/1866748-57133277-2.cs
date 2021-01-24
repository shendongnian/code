    public class CPFAttributeAdapter : AttributeAdapterBase<CPFAttribute>
    {
            public CPFAttributeAdapter(CPFAttributeattribute, IStringLocalizer stringLocalizer) : base(attribute, stringLocalizer) { }
        
        public override void AddValidation(ClientModelValidationContext context) { }
            public override string GetErrorMessage(ModelValidationContextBase validationContext)
            {
                return GetErrorMessage(validationContext.ModelMetadata, validationContext.ModelMetadata.GetDisplayName());
            }
        }
