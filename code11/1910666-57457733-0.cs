public struct SomeTypes
{
	private Random random;
    public string[] types;
	
	public SomeTypes(IList<string> types)
	{
		this.types = (string[]) types;
		random = new Random();
	}
	
	public string takeOneRandom()
	{
		int index = random.Next(types.Length);
		return types[index];
	}
}
SomeTypes myTypes = new SomeTypes(new string[]{"t0", "t1", "t2", "t3"});
		
Console.WriteLine(myTypes.takeOneRandom());
