    public class DeviceService 
    { 
       public bool ValidateDevice(IDeviceDataObject device) 
       { 
           IValidatableObject v = device as IValidatableObject;
           
           if (v != null)
               return device.Validate();
           return false;
       } 
    } 
