     public static class EditContextFluentValidationExtensions
    {
        public static EditContext AddFluentValidation(this EditContext editContext, bool shouldValidate)
        {
            if (editContext == null)
            {
                throw new ArgumentNullException(nameof(editContext));
            }
            var messages = new ValidationMessageStore(editContext);
            editContext.OnValidationRequested +=
                (sender, eventArgs) => ValidateModel((EditContext)sender, messages);
            editContext.OnFieldChanged +=
                (sender, eventArgs) => ValidateField(editContext, messages, eventArgs.FieldIdentifier, shouldValidate);
            return editContext;
        }
        private static void ValidateModel(EditContext editContext, ValidationMessageStore messages)
        {
            var validator = GetValidatorForModel(editContext.Model);
            var validationResults = validator.Validate(editContext.Model);
            messages.Clear();
            foreach (var validationResult in validationResults.Errors)
            {
                messages.Add(editContext.Field(validationResult.PropertyName), validationResult.ErrorMessage);
            }
            editContext.NotifyValidationStateChanged();
        }
        private static void ValidateField(EditContext editContext, ValidationMessageStore messages, in FieldIdentifier fieldIdentifier, bool shouldValidate)
        {
            Console.WriteLine(fieldIdentifier.FieldName.ToString());
            if (shouldValidate)
            {
                var properties = new[] { fieldIdentifier.FieldName };
                var context = new FluentValidation.ValidationContext(fieldIdentifier.Model, new PropertyChain(), new MemberNameValidatorSelector(properties));
                var validator = GetValidatorForModel(fieldIdentifier.Model);
                var validationResults = validator.Validate(context);
                messages.Clear(fieldIdentifier);
                foreach (var validationResult in validationResults.Errors)
                {
                    messages.Add(editContext.Field(validationResult.PropertyName), validationResult.ErrorMessage);
                }
                editContext.NotifyValidationStateChanged();
            }
        }
        private static IValidator GetValidatorForModel(object model)
        {
            var abstractValidatorType = typeof(AbstractValidator<>).MakeGenericType(model.GetType());
            var modelValidatorType = Assembly.GetExecutingAssembly().GetTypes().FirstOrDefault(t => t.IsSubclassOf(abstractValidatorType));
            var modelValidatorInstance = (IValidator)Activator.CreateInstance(modelValidatorType);
            return modelValidatorInstance;
        }
    }
