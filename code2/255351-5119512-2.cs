    try
    {
        // Call into service layer
    }
    catch (BusinessLayerException ex)
    {
        this.ValidationSummary1.Add(new CustomValidator
        {
            ErrorMessage = ex.Message, IsValid = false
        });
    }
