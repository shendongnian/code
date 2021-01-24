	IMapper dtoToBusinessMapper = new MapperConfiguration(cfg =>
	{
		cfg.AddConditionalObjectMapper()
		   .Where((s, d) => s.Name == d.Name.Substring(2).Pascalize());
		cfg.SourceMemberNamingConvention = new LowerUnderscoreNamingConvention();
		cfg.DestinationMemberNamingConvention = new PascalCaseNamingConvention();
	}).CreateMapper();
	IMapper businessToDtoMapper = new MapperConfiguration(cfg =>
	{
		cfg.AddConditionalObjectMapper()
		   .Where((s, d) => s.Name == "T_" + d.Name.Underscore().ToUpperInvariant());
		cfg.SourceMemberNamingConvention = new PascalCaseNamingConvention();
		cfg.DestinationMemberNamingConvention = new LowerUnderscoreNamingConvention(); 
	}).CreateMapper();
	T_ACCOUNT tableRow = new T_ACCOUNT()
	{
		DELETED = 0,
		EMAIL = "asdf@asdf.cz",
		ID = 8,
		IS_EMAIL_CONFIRMED = 1,
		PROFILE_ID = 11,
		TIME = DateTime.Now
	};
	Account businessModel = dtoToBusinessMapper.Map<Account>(tableRow);
	T_ACCOUNT backToDto = businessToDtoMapper.Map<T_ACCOUNT>(businessModel);
