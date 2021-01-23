    #region IDataErrorInfo & Validation Members
    
    /// <summary>
    /// List of Property Names that should be validated
    /// </summary>
    protected List<string> ValidatedProperties = new List<string>();
    
    public abstract string GetValidationError(string propertyName);
    
    string IDataErrorInfo.Error { get { return null; } }
    
    string IDataErrorInfo.this[string propertyName]
    {
        get { return this.GetValidationError(propertyName); }
    }
    
    public bool IsValid
    {
        get
        {
            return (GetValidationError() == null);
        }
    }
    
    public string GetValidationError()
    {
        string error = null;
    
        if (ValidatedProperties != null)
        {
            foreach (string s in ValidatedProperties)
            {
                error = GetValidationError(s);
                if (error != null)
                {
                    return error;
                }
            }
        }
    
        return error;
    }
    
    #endregion // IDataErrorInfo & Validation Members
