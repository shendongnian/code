    public string GetValidationError(string propertyName)
    {
        if (propertyName == "GeneralInvoiceTypes")
            return GeneralInvoiceTypes.GetValidationError();
        return null;
    }
