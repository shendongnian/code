public class CommonMappingProfile : Profile
{
	public CommonMappingProfile()
	{
		CreateMapLongToEnum<B>();
	}
	private void CreateMapLongToEnum<T>() where T : Enum
	{
		CreateMap<long, T>().ConvertUsing(l => (T)Enum.ToObject(typeof(T) , l));
	}
}
public class MapperConfigFactory
{
	public MapperConfiguration Create(Action<IMapperConfigurationExpression> configExpression = null)
	{
		var config = new MapperConfiguration(cfg =>
		{
			cfg.AddProfile<CommonMappingProfile>();
			configExpression?.Invoke(cfg);
		});
		return config;
	}
}
Then your code:
var autoMapperConfigFactory = new MapperConfigFactory();
var autoMapper = new Mapper(autoMapperConfigFactory.Create(cfg =>
{
    /* Custom settings if required */				
}));
var result = autoMapper.Map<A>(dictionary);
