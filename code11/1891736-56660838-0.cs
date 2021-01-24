    public Mdl UpdateId(int Id)
	{
		var EmpId = _uow.Register.GetByID(Id);
		if(EmpId != null)
		{
			var config = new MapperConfiguration(cfg =>
			{
				cfg.CreateMap<Mdl, Table_1>();
			});
			IMapper mapper = config.CreateMapper();
			var dest = mapper.Map<Table_1,Mdl>(EmpId);
			return dest;
		}
		return null;
	}
