    protected internal bool TryValidateModel(object model, string prefix)
    {
        if (model == null)
        {
            throw new ArgumentNullException("model");
        }
        foreach (ModelValidationResult result in ModelValidator.GetModelValidator(ModelMetadataProviders.Current.GetMetadataForType(delegate {
            return model;
        }, model.GetType()), base.ControllerContext).Validate(null))
        {
            this.ModelState.AddModelError(DefaultModelBinder.CreateSubPropertyName(prefix, result.MemberName), result.Message);
        }
        return this.ModelState.IsValid;
    }
 
 
