    static readonly string[] ValidatedProperties =
    {
        "Foo",
        "Bar"
    };
    /// <summary>
    /// Returns true if this object has no validation errors.
    /// </summary>
    public bool IsValid
    {
        get
        {
            foreach (string property in ValidatedProperties)
            {
                
                if (GetValidationError(property) != null) // there is an error
                    return false;
            }
            return true;
        }
    }
    private string GetValidationError(string propertyName)
    {
        string error = null;
        switch (propertyName)
        {
            case "Foo":
                error = this.ValidateFoo();
                break;
            case "Bar":
                error = this.ValidateBar();
                break;
            default:
                error = null;
                throw new Exception("Unexpected property being validated on Service");
        }
        return error;
    }
