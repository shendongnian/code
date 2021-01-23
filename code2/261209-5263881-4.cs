    Mapper.CreateMap<MSValidation.ValidationResult, IValidationResult>().ConstructUsing(
                dest =>
                new ValidationResult(
                    dest.Key,
                    dest.Message,
                    dest.Target.GetType(),
                    dest.NestedValidationResults.Select(mappingManager.Map<MSValidation.ValidationResult, ValidationResult>).ToList()));
