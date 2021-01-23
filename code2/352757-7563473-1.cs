    public static void Main (string[] args)
    {
    	var nonInheritedInterfaces = typeof(Test).GetImmediateInterfaces();
    	foreach(var iface in nonInheritedInterfaces)
    	{
    		Console.WriteLine(iface);
    	}
    	Console.Read();
    }
    class Test : ITest { }
    interface ITest : ITestParent { }
    interface ITestParent { }
    public static class TypeExtensions
    {
        public static Type[] GetImmediateInterfaces(this Type type)
        {
            var allInterfaces = type.GetInterfaces();
            var nonInheritedInterfaces = new HashSet<Type>(allInterfaces);
            foreach(var iface in allInterfaces)
            {
                RemoveInheritedInterfaces(iface, nonInheritedInterfaces);
            }
            return nonInheritedInterfaces.ToArray();
        }
        private static void RemoveInheritedInterfaces(Type iface, HashSet<Type> ifaces)
        {
            foreach(var inheritedIface in iface.GetInterfaces())
            {
                ifaces.Remove(inheritedIface);
                RemoveInheritedInterfaces(inheritedIface, ifaces);
            }
        }
    }
    
    private static void RemoveInheritedInterfaces(Type iface, Dictionary<Type, Type> interfaces)
    {
    	foreach(var inheritedInterface in iface.GetInterfaces())
    	{
    		interfaces.Remove(inheritedInterface);
    		RemoveInheritedInterfaces(inheritedInterface, interfaces);
    	}
    }
