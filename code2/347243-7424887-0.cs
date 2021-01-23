    public bool ValidateDevice(IDeviceDataObject someobj)
    {
        if(someobj is IValidatableObject)
        {
            return ((IValidatableObject)device).Validate();
        }
    }
