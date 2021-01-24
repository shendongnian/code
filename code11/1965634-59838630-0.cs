    using System.Linq;
    var config = new MapperConfiguration(cfg =>
    {
        cfg.CreateMap<Device, DeviceDto>();
        cfg.CreateMap<DeviceDto, Device>()
            .AfterMap((src, dst) => src.Results.Select(result => dst.AddResult(result)));
    });
