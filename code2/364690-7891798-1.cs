    class DeviceModel : BaseModel<Device>
    {
        public override Device New()
        {
            return new Device();
        }
    }
