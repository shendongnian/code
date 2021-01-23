    string input = "myteststring";
    var myAttribute = new MyAttribute()
    var result = attribute.GetValidationResult(input, new ValidationContext(input));
    
    var isSuccess = result == ValidationResult.Success;
    var errorMessage = result?.ErrorMessage;
