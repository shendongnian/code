    internal sealed class OldWayModelBinder : DefaultModelBinder {
        protected override void OnModelUpdated(ControllerContext controllerContext, ModelBindingContext bindingContext) {
            foreach (var validationResult in ModelValidator.GetModelValidator(bindingContext.ModelMetadata, controllerContext).Validate(null)) {
                string subPropertyName = CreateSubPropertyName(bindingContext.ModelName, validationResult.MemberName);
                if (bindingContext.PropertyFilter(subPropertyName)) {
                    if (bindingContext.ModelState.IsValidField(subPropertyName)) {
                        bindingContext.ModelState.AddModelError(subPropertyName, validationResult.Message);
                    }
                }
            }
        }
    }
