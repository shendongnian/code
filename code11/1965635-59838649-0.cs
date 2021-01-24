    var config = new MapperConfiguration(
        cfg =>
        {
	        cfg.CreateMap<Device, DeviceDto>()
                .ReverseMap()
					.AfterMap((src, dest) =>
					{ 
						foreach (Result result in src.Results)
						{
							dest.AddResult(result);
						}
					});
        });
