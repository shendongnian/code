    var results = new List<ValidationResult>();
    var vc = new ValidationContext(myObject, null, null) { MemberName = "UserName"};
    var isValid = Validator.TryValidateProperty(value, vc, results);
    // get all the errors
    var errors = Array.ConvertAll(results.ToArray(), o => o.ErrorMessage);
