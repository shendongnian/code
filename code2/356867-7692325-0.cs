    public string GetValidationError(string propertyName)
    {
        string s = null;
    
        switch (propertyName)
        {
            case "FirstName":
            case "LastName":
                s = Person.GetValidationError(propertyName);
                break;
        }
    
        return s;
    }
    string IDataErrorInfo.this[string propertyName]
    {
        get { return this.GetValidationError(propertyName); }
    }
