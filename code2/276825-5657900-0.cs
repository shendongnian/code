    public class LookupModelBinder<TModel> : DefaultModelBinder
        where TModel : class
    {
        private string _key;
        public LookupModelBinder(string key = null)
        {
            _key = key ?? typeof(TModel).Name;
        }
        public override object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
        {
            var dbSession = ((IControllerWithSession)controllerContext.Controller).DbSession;
            var modelName = bindingContext.ModelName;
            TModel model = null;
            ValueProviderResult vpResult = bindingContext.ValueProvider.GetValue(bindingContext.ModelName);
            if (vpResult != null)
            {
                bindingContext.ModelState.SetModelValue(modelName, vpResult);
                var id = (int?)vpResult.ConvertTo(typeof(int));
                model = id == null ? null : dbSession.Get<TModel>(id.Value);
            }
            if (model == null)
            {
                ModelValidator requiredValidator = ModelValidatorProviders.Providers.GetValidators(bindingContext.ModelMetadata, controllerContext).Where(v => v.IsRequired).FirstOrDefault();
                if (requiredValidator != null)
                {
                    foreach (ModelValidationResult validationResult in requiredValidator.Validate(bindingContext.Model))
                    {
                        bindingContext.ModelState.AddModelError(modelName, validationResult.Message);
                    }
                }
            }
            return model;
        }
    }
