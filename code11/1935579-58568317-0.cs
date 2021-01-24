static void Main(string[] args)
{
	try{
    var mapperCfg = new AutoMapper.MapperConfiguration(cfg =>
    {
		cfg.CreateMap<Source, DestinationOuter>().ForCtorParam("destinationNested", o => o.MapFrom(s => new DestinationNested(s.InnerValue)));
    });
	mapperCfg.AssertConfigurationIsValid();
    var mapper = mapperCfg.CreateMapper();
	var src = new Source { OuterValue = 999, InnerValue = 111 };
	mapper.Map<DestinationOuter>(src).Dump();
	}catch(Exception ex){
		ex.ToString().Dump();
	}
}
public class Source
{
    public int OuterValue { get; set; }
    public int InnerValue { get; set; }
}
public class DestinationOuter
{
    public int OuterValue { get; }
    public DestinationNested DestinationNested { get; }
    public DestinationOuter(int outerValue, DestinationNested destinationNested)
    {
        this.OuterValue = outerValue;
        this.DestinationNested = destinationNested;
    }
}
public class DestinationNested
{
    public int NestedValue { get; private set; }
    public DestinationNested(int nestedValue)
    {
        this.NestedValue = nestedValue;
    }
}
