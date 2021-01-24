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
If you want to keep your fields, there are a couple of things you can do. You can provide an indexer with a switch, have a dictionary, or, as shown in other answer(s) you can use reflection.
Here is a solution with an indexer and a switch:
public struct SomeTypes
{
	private Random random;
	
	public string type1;
    public string type2;
    public string type3;
    public string type4;
	
	public SomeTypes(string t1, string t2, string t3, string t4)
	{
		type1 = t1;
		type2 = t2;
		type3 = t3;
		type4 = t4;
		random = new Random();
	}
	
	public string this[int idx]
	{
		get
		{
			switch (idx)
			{
				case 0 : return type1;
				case 1: return type2;
				case 2: return type3;
				case 3: return type4;
				default: throw new ArgumentException();
			}
		}
	}
	
	public string takeOneRandom()
	{
		int index = random.Next(4);
		return this[index];
	}
}
		SomeTypes myTypes = new SomeTypes("t0", "t1", "t2", "t3");
		
		Console.WriteLine(myTypes.takeOneRandom());
