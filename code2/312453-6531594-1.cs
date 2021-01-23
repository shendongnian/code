    /// <summary>
    /// Checks if all parameters on the Model are valid and ready to be saved
    /// </summary>
    protected bool CanSave
    {
        get
        {
            return modelOfThisVM.IsValid;
        }
    }
