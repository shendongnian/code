    public static class EditContextFluentValidationExtensions
        {
            public static EditContext AddFluentValidation(this EditContext editContext)
            {
                if (editContext == null)
                {
                    throw new ArgumentNullException(nameof(editContext));
                }
    
                var messages = new ValidationMessageStore(editContext);
    
                editContext.OnValidationRequested +=
                    (sender, eventArgs) => ValidateModel((EditContext)sender, messages);
    
                editContext.OnFieldChanged +=
                    (sender, eventArgs) => ValidateField(editContext, messages, eventArgs.FieldIdentifier);
    
                return editContext;
            }
    
            private static void ValidateModel(EditContext editContext, ValidationMessageStore messages)
            {
                var validator = GetValidatorForModel(editContext.Model);
    
                if (validator == null)
                    return;
    
                var validationResults = validator.Validate(editContext.Model);
    
                messages.Clear();
                foreach (var validationResult in validationResults.Errors)
                {
                    messages.Add(editContext.Field(validationResult.PropertyName), validationResult.ErrorMessage);
                }
    
                editContext.NotifyValidationStateChanged();
            }
    
            private static void ValidateField(EditContext editContext, ValidationMessageStore messages, in FieldIdentifier fieldIdentifier)
            {
                var properties = new[] { fieldIdentifier.FieldName };
                var context = new ValidationContext(fieldIdentifier.Model, new PropertyChain(), new MemberNameValidatorSelector(properties));
    
                var validator = GetValidatorForModel(fieldIdentifier.Model);
    
                if (validator == null)
                    return;
    
                var validationResults = validator.Validate(context);
    
                messages.Clear(fieldIdentifier);
    
                foreach (var validationResult in validationResults.Errors)
                {
                    messages.Add(editContext.Field(validationResult.PropertyName), validationResult.ErrorMessage);
                }
    
                editContext.NotifyValidationStateChanged();
            }
    
            private static IValidator GetValidatorForModel(object model)
            {
                var abstractValidatorType = typeof(AbstractValidator<>).MakeGenericType(model.GetType());
                var modelValidatorType = Assembly.GetExecutingAssembly().GetTypes().FirstOrDefault(t => t.IsSubclassOf(abstractValidatorType));
    
                if (modelValidatorType == null)
                    return null;
    
                var modelValidatorInstance = (IValidator)Activator.CreateInstance(modelValidatorType);
    
                return modelValidatorInstance;
            }
        }
