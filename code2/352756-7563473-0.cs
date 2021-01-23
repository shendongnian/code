    public static void Main (string[] args)
    {
    	var interfaces = typeof(Test).GetInterfaces();
    	Dictionary<Type, Type> nonInheritedInterfaces = new Dictionary<Type, Type>();
    	foreach(var iface in interfaces)
    	{
    		nonInheritedInterfaces.Add(iface, iface);
    	}
    	foreach(var iface in interfaces)
    	{
    		RemoveInheritedInterfaces(iface, nonInheritedInterfaces);
    	}
    	foreach(var iface in nonInheritedInterfaces)
    	{
    		Console.WriteLine(iface);
    	}
    	Console.Read();
    }
    
    private static void RemoveInheritedInterfaces(Type iface, Dictionary<Type, Type> interfaces)
    {
    	foreach(var inheritedInterface in iface.GetInterfaces())
    	{
    		interfaces.Remove(inheritedInterface);
    		RemoveInheritedInterfaces(inheritedInterface, interfaces);
    	}
    }
