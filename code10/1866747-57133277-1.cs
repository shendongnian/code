    private readonly IValidationAttributeAdapterProvider _baseProvider = new ValidationAttributeAdapterProvider();
    public IAttributeAdapter GetAttributeAdapter(CPFAttribute attribute, IStringLocalizer stringLocalizer)
    {
        if (attribute is CPFAttribute)
            return new CPFAttributeAdapter(attribute as CPFAttribute, stringLocalizer);
        else
            return _baseProvider.GetAttributeAdapter(attribute, stringLocalizer);
    }
    public IAttributeAdapter GetAttributeAdapter(ValidationAttribute attribute, IStringLocalizer stringLocalizer)
    {
        if (attribute is CPFAttribute) return
                new CPFAttributeAdapter(attribute as CPFAttribute,
        stringLocalizer);
        else return _baseProvider.GetAttributeAdapter(attribute, stringLocalizer);
    }
