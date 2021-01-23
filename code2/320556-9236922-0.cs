    public ObservableCollection<string> Errors
    {
        get
        {
            ObservableCollection<string> errors = new ObservableCollection<string>();
            errors.AddUniqueIfNotEmpty(this["PropertyToValidate1"]);
            errors.AddUniqueIfNotEmpty(this["PropertyToValidate2"]);
            ...
            errors.AddUniqueIfNotEmpty(this["PropertyToValidateN"]);
            return errors;
        }
    }
