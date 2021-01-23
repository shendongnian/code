    public sealed class DeviceManagerWrapper : MarshalByRefObject {
      public DeviceManagerWrapper(){}
      public DeviceManeger DeviceManager {
        get { return DeviceManager.Instance; }
      }
    }
