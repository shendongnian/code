	var config = new MapperConfiguration(cfg => { 
	
	cfg.CreateMap<Source, Destination>()
		.ForMember(
			dest => dest.Variable2, 
			opt => {
				opt.SetMappingOrder(1); // Will be mapped first.
				opt.MapFrom(src => testFunction(src.Variable1));
			})
		.ForMember(
			dest => dest.Variable3, 
			opt => {
				opt.SetMappingOrder(2); // Will be mapped second.
				opt.MapFrom((src, dest) => dest.Variable2);
			});
	});
	IMapper mapper = new Mapper(config);
	var source = new Source {
		Variable1 = "foo"
		};
	var destination = mapper.Map<Destination>(source);
	Console.WriteLine($"variable2: {destination.Variable2}");
	Console.WriteLine($"variable3: {destination.Variable3}");
	// variable2: FOO 377dd1f8-ec1e-4f02-87b6-64f0cc47e989
	// variable3: FOO 377dd1f8-ec1e-4f02-87b6-64f0cc47e989
