    // You can call this method from both places
    protected bool ValidateLastName()
    {
        bool isValid = !String.IsNullOrWhiteSpace(txtDeliveryLastName.Text);
        txtDeliveryLastName.BackColor = isValid ? Color.White : Color.LightPink;
        return isValid;
    }
    // This would be the modified Event Handler
    protected void CustomValidatorDelLN_ServerValidate(object sender,
        ServerValidateEventArgs args)
    {
        args.IsValid = ValidateLastName();
    }
