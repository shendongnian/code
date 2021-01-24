public class Dest
{
	public FooGroup FooGroup { get; set; }
	public Dest(FooDest fooDest) 
	{
		FooGroup = new FooGroup { FooDest = fooDest };
	}
}
[..]
Mapper.CreateMap<FooSrc, Dest>();
Mapper.Map<List<Dest>>(listOfFooSrc);
