void Main()
{
}
class B
{
	public int MyProperty { get; set; }
	public B() { }
}
class A
{
	public B B { get; private set; }
	public A() { }
}
class Program
{
	static void Main(string[] args)
	{
		var config = new MapperConfiguration(cfg =>
		{
			cfg.CreateMap<B, A>()
			   .ForMember(dest => dest.B, opt => opt.MapFrom(src => src));
		});
		var mapper = new Mapper(config);
		var b = new B() { MyProperty = 123 };
		var a = mapper.Map<A>(b);
		
		config.AssertConfigurationIsValid();
		Debug.Assert(a.B != null);
		
		Debug.Assert(a.B.MyProperty == 123);
		
	}
}
``
