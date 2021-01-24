    void Main()
    {
    	var s = new StringBuilder();
    	s.AppendLine("Id,Name");
    	s.AppendLine($"{Guid.NewGuid()},one");
    	using (var reader = new StringReader(s.ToString()))
    	using (var csv = new CsvReader(reader))
    	{
    		csv.Configuration.PrepareHeaderForMatch = (header, indexer) => header.ToLower();
    		csv.GetRecords<ImmutableTest>().ToList().Dump();
    	}
    }
    
    public class ImmutableTest
    {
    	public Guid Id { get; }
    
    	public string Name { get; }
    
    	public ImmutableTest(string name) : this(Guid.NewGuid(), name)
    	{
    	}
    
    	public ImmutableTest(Guid id, string name)
    	{
    		Id = id;
    		Name = name;
    	}
    }
