    public class ServiceLocatorImplementer : IMethodReplacer
    {
        private readonly Type _forType;
        public ServiceLocatorImplementer(Type forType)
        {
            this._forType = forType;
        }
        protected IEnumerable GetAllImplementers()
        {
            var idObjects = Spring.Context.Support.ContextRegistry.GetContext()
                .GetObjectsOfType(_forType);
            return idObjects.Values;
        }
        public object Implement(object target, MethodInfo method, object[] arguments)
        {
            return GetAllImplementers();
        }
    }
