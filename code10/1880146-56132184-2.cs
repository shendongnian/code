    public List<Destination> GetStud(Source source)
    {  
        MapperConfigurationExpression cfg = new MapperConfigurationExpression();
        cfg.ValidateInlineMaps = false;
        cfg.CreateMap<StudentName,  Destination>()
	       .ForMember(a=> a.FirstName, opt => opt.MapFrom(itm=> itm.Name));
        MapperConfiguration mapperConfig = new MapperConfiguration(cfg);
        IMapper mapper = new Mapper(mapperConfig);		
		
    	var viewModel = mapper.Map<List<Destination>>(source.studentName);
        return viewModel;
    }
