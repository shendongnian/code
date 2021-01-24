    private void EnforceBindRequiredAndValidate(
                ObjectModelValidator baseObjectValidator,
                ActionContext actionContext,
                ParameterDescriptor parameter,
                ModelMetadata metadata,
                ModelBindingContext modelBindingContext,
                ModelBindingResult modelBindingResult)
            {
                RecalculateModelMetadata(parameter, modelBindingResult, ref metadata);
     
                if (!modelBindingResult.IsModelSet && metadata.IsBindingRequired)
                {
                    // Enforce BindingBehavior.Required (e.g., [BindRequired])
                    var modelName = modelBindingContext.FieldName;
                    var message = metadata.ModelBindingMessageProvider.MissingBindRequiredValueAccessor(modelName);
                    actionContext.ModelState.TryAddModelError(modelName, message);
                }
                else if (modelBindingResult.IsModelSet)
                {
                   // Enforce any other validation rules
                    baseObjectValidator.Validate(
                        actionContext,
                        modelBindingContext.ValidationState,
                        modelBindingContext.ModelName,
                        modelBindingResult.Model,
                        metadata);
                }
                else if (metadata.IsRequired)
                {
                    // We need to special case the model name for cases where a 'fallback' to empty
                    // prefix occurred but binding wasn't successful. For these cases there will be no
                    // entry in validation state to match and determine the correct key.
                    //
                    // See https://github.com/aspnet/Mvc/issues/7503
                    //
                    // This is to avoid adding validation errors for an 'empty' prefix when a simple
                    // type fails to bind. The fix for #7503 uncovered this issue, and was likely the
                    // original problem being worked around that regressed #7503.
                    var modelName = modelBindingContext.ModelName;
     
                    if (string.IsNullOrEmpty(modelBindingContext.ModelName) &&
                        parameter.BindingInfo?.BinderModelName == null)
                    {
                        // If we get here then this is a fallback case. The model name wasn't explicitly set
                        // and we ended up with an empty prefix.
                        modelName = modelBindingContext.FieldName;
                    }
     
                    // Run validation, we expect this to validate [Required].
                    baseObjectValidator.Validate(
                        actionContext,
                        modelBindingContext.ValidationState,
                        modelName,
                        modelBindingResult.Model,
                        metadata);
                }
            }
