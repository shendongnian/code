    bool isSecondObjectValid = userProfileModelObject.GetType().GetProperties()
        .Where(pi => pi.PropertyType == typeof(string))
        .Select(pi => (string)pi.GetValue(myObject))
        .Any(value => string.IsNullOrEmpty(value));
    
    
    bool validationResult = false;
    validationResult = !isSecondObjectValid ? 
                              TryValidateModel(accountModelInstance) :
                              TryValidateModel(userProfileModelObject);
