    public DeviceShortMacID : IDeviceID
    {
        private ID _ID;
        public DeviceShortMacID() { }
        public DeviceShortMacID(IDeviceID id)
        {
            if (id is DeviceshortMacID)
                this._ID = id.GetID();
           else 
                this._ID = this.ConvertFrom(id);
        }
        public ID ConvertFrom(IDeviceID oldID) { ... convert code ...}
        public ID GetID() { return this_ID; }
    }
    
    public interface IDeviceID
    {
        public ID GetID();
        public ID ConvertFrom(IDeviceID oldID);
    }
    
    public class ID { } // I don't know what you return so I'm making up this class
