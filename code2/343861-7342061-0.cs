    public interface INode
    {
    	string Name { get; set;}
    }
    
    class DeviceNode : INode
    {
    	public string Name { get; set; }
    	public string SomethingElse { get; set; }
    }
    
    public interface INodeProvider
    {
    	void LoadNodes(INode parent, Action<IEnumerable<INode>> action);
    }
    
    class NodeProvider : INodeProvider
    {
    	public void LoadNodes(INode parent, Action<IEnumerable<INode>> action)
    	{
    		List<DeviceNode> devices = new List<DeviceNode>() { new DeviceNode(){ Name="DeviceNode1", SomethingElse="OtherProperty" } };
    
    		action(devices);
    	}
    }
    
    class Program
    {
    	static void Main(string[] args)
    	{
    		var provider = new NodeProvider();
    
    		provider.LoadNodes(null, (list) => Console.WriteLine(string.Join(", ", list.Select(node => node.Name).ToArray())));
    
    		Console.ReadLine();
    	}
    }
