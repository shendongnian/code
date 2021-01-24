    static void Main(string[] args)
    {
    	IMapper mapper = new MapperConfiguration(cfg => {
    		cfg.CreateMap<IEnumerable<Cars>, IEnumerable<CarsDTO>>().ConvertUsing<CarPartConverter>();
    	}).CreateMapper();
    
    	List<Cars> cars = new List<Cars>
    	{
    		new Cars {PartId = 1, PartCode = "WINDOW", CarId = 1, CarCode = "MUSTANG", Enabled = true},
    		new Cars {PartId = 2, PartCode = "WHEELS", CarId = 1, CarCode = "MUSTANG", Enabled = true},
    		new Cars {PartId = 3, PartCode = "BUMPER", CarId = 2, CarCode = "MONDEO", Enabled = true}
    	};
    
    	IEnumerable<CarsDTO> dtos = mapper.Map<IEnumerable<CarsDTO>>(cars);
    
    	Console.WriteLine(JsonConvert.SerializeObject(dtos, Formatting.Indented));
    	Console.ReadLine();
    }
