	IEnumerable<ObjectA> ListOfObjectA = new List<ObjectA> {
		new ObjectA { Name = "One" },
		new ObjectA { Name = "Two" },
		new ObjectA { Name = "Three" }
		};
	Mapper.Initialize(cfg =>
		cfg.CreateMap<(ObjectA, IEnumerable<ObjectA>), ViewModelA>()
			.ForMember(
				dest => dest.Name,
				opt => opt.MapFrom<CustomResolver>()
			));                
	var viewModels = 
		Mapper.Map<IEnumerable<ViewModelA>>(
			ListOfObjectA.Select(o => (o, ListOfObjectA))
			);
