    public override IEnumerable<ModelValidationResult> Validate(object container) {
      // Per the WCF RIA Services team, instance can never be null (if you have
      // no parent, you pass yourself for the "instance" parameter).
      ValidationContext context = new ValidationContext(
        container ?? Metadata.Model, null, null);
      context.DisplayName = Metadata.GetDisplayName();
      ValidationResult result = 
        Attribute.GetValidationResult(Metadata.Model, context);
      if (result != ValidationResult.Success) {
        yield return new ModelValidationResult {
          Message = result.ErrorMessage
        };
      }
    }
