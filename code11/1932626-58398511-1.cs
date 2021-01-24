    public interface IDeviceTag { }
    public interface IDeviceTagBag<out TDeviceTag>
        where TDeviceTag : IDeviceTag
    { }
    public interface IDevice<TDeviceTagBag>
        where TDeviceTagBag : IDeviceTagBag<IDeviceTag>
    { }
