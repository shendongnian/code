    public class NameConvention : ISubDependencyResolver
    {
        public bool CanResolve(CreationContext context,
            ISubDependencyResolver contextHandlerResolver,
            ComponentModel model, DependencyModel dependency)
        {
            return dependency.TargetType == typeof(string)
                && dependency.DependencyKey == "name";
        }
        public object Resolve(CreationContext context,
            ISubDependencyResolver contextHandlerResolver,
            ComponentModel model, DependencyModel dependency)
        {
            return "foo"; // use whatever value you'd like,
                          // or derive it from the provided models
        }
    }
