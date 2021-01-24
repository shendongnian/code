    public void ValidateModel()
    {
        ValidationContext context = new ValidationContext(this);
        List<ValidationResult> results = new List<ValidationResult>();
    
        Validator.TryValidateObject(this, context, results, true);
    
        foreach (KeyValuePair<string, List<string>> valuePair in _validationErrors.ToList())
        {
            if (!results.All(r => r.MemberNames.All(m => m != valuePair.Key)))
            {
                continue;
            }
    
            _validationErrors.TryRemove(valuePair.Key, out List<string> _);
            RaiseErrorChanged(valuePair.Key);
        }
    
        IEnumerable<IGrouping<string, ValidationResult>> q = from r in results
            from m in r.MemberNames
            group r by m
            into g
            select g;
    
        foreach (IGrouping<string, ValidationResult> prop in q)
        {
            List<string> messages = prop.Select(r => r.ErrorMessage).ToList();
    
            if (_validationErrors.ContainsKey(prop.Key))
            {
                _validationErrors.TryRemove(prop.Key, out List<string> _);
            }
    
            _validationErrors.TryAdd(prop.Key, messages);
            RaiseErrorChanged(prop.Key);
        }
    }
