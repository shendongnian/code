    [CollectionDataContract(Name = "collection", ItemName = "item", Namespace = "")]
    public class ConfigWrapper : List<string>
    {
    	public ConfigWrapper() : base() { }
    	public ConfigWrapper(IEnumerable<string> items) : base(items) { }
    	public ConfigWrapper(int capacity) : base(capacity) { }
    }
