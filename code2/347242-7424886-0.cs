    public class DeviceService
    {
       public bool ValidateDevice<T>(T device) where T: IDeviceDataObject, IValidatableObject
       {
           return device.Validate(); 
       }
    }
