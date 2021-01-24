    public class CountryRegion
    {
    	public CountryRegion(string name) => Name = name;    
    	public CountryRegion(string id, string name) : this(name) => Id = id;
    
    	public string Id { get; protected set; }
    	public string Name { get; protected set; }
    
    	private readonly List<StateProvince> _stateProvinces = new List<StateProvince>(); // Private collection for DDD usage
    	public IReadOnlyCollection<StateProvince> StateProvinces => _stateProvinces.AsReadOnly(); // Public like read only collection public immutable exposure
    }
    public class StateProvince
    {
    	public StateProvince(string name) => Name = name;
    	public StateProvince(string id, string name) : this(name) => Id = id;
    
    	public string Id { get; protected set; }
    	public string Name { get; protected set; }
    
    	public string CountryRegionId { get; protected set; }
    	public virtual CountryRegion CountryRegion { get; protected set; }
    }
