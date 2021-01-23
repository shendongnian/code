    // In the generic method
    Validator.TryValidateProperty(
        typeof(T).GetProperty(PeropertyName).Name, 
        new ValidationContext(t, null, null) { MemberName =  PeropertyName},
        ValidationMessages);
    // The working call
    Validator.TryValidateProperty(
        lookups.Description,
        new ValidationContext(lookups, null, null) { MemberName = "Description" },
        results);
