    public void Validate(T entity)
    {
        var context = new ValidationContext(entity, null, null);
        var results = new List<ValidationResult>();
        bool valid = Validator.TryValidateObject(entity, context, results, true);
        if (!valid)
            ; // do something fancy with the results here, perhaps
    }
