    public interface IDeviceTag { }
    public interface IDeviceTagBag<TDeviceTag>
        where TDeviceTag : IDeviceTag
    { }
    public interface IDevice<TDeviceTagBag>
        where TDeviceTagBag : IDeviceTagBag<IDeviceTag>
    { }
