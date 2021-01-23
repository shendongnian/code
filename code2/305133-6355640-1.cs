    [AttributeUsage(AttributeTargets.Assembly, AllowMultiple = false)]
    public sealed class AssemblyPluginAttribute : Attribute
    {
    	private readonly AssemblyPluginType _type;
    
    	public AssemblyPluginType PluginType
    	{
    		get { return _type; }
    	}
    
    	public AssemblyPluginAttribute(AssemblyPluginType type)
    	{
    		_type = type;
    	}
    }
    
    [AttributeUsage(AttributeTargets.Assembly, AllowMultiple = false)]
    public sealed class AssemblyPluginConflictAttribute : Attribute
    {
    	private readonly AssemblyPluginType[] _conflicts;
    
    	public AssemblyPluginType[] Conflicts
    	{
    		get { return _conflicts; }
    	} 
    
    	public AssemblyPluginConflictAttribute(params AssemblyPluginType[] conflicts)
    	{
    		_conflicts = conflicts;
    	}
    }
