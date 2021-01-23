    public class ServiceLocatorImplementer : IMethodReplacer
    {
        protected IEnumerable<ICustomInterfaceThatDoesSomething> GetAllImplementers()
        {
            var idObjects = Spring.Context.Support.ContextRegistry.GetContext()
                .GetObjectsOfType(typeof(ICustomInterfaceThatDoesSomething));
            return idObjects.Values.Cast<ICustomInterfaceThatDoesSomething>();
        }
        public object Implement(object target, MethodInfo method, object[] arguments)
        {
            return GetAllImplementers();
        }
    }
