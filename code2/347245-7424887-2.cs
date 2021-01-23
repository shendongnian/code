    public bool ValidateDevice(IDeviceDataObject someobj)
    {
        if(someobj is IValidatableObject)
        {
            return ((IValidatableObject)device).Validate();
        }
        return //something that makes sense if the device is not validatable
    }
