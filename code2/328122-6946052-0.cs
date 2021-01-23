    using System.ComponentModel.DataAnnotations;
    Validator.TryValidateProperty(propertyValue,
                                  new ValidationContext(this, null, null)
                                     { MemberName = propertyName },
                                  validationResults);
