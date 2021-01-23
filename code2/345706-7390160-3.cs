    /// <summary>
    /// Clears all validation errors
    /// </summary>
    void ClearAllValidationErrors()
    {
        Validation.ClearInvalid(TBNumItems.GetBindingExpression(TextBox.TextProperty));
    }
    /// <summary>
    ///  Revalidates everything
    /// </summary>
    void RevalidateAll()
    {
        ClearAllValidationErrors();
        TBNumItems.GetBindingExpression(TextBox.TextProperty).UpdateSource();
    }
