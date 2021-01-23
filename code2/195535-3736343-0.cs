    public class NonCyclicCollectionResolver : ISubDependencyResolver
    {
        private readonly IKernel kernel;
        private readonly bool    allowEmptyCollections;
        public NonCyclicCollectionResolver(
            IKernel kernel,
            bool    allowEmptyCollections = false
        ) {
            this.kernel                = kernel;
            this.allowEmptyCollections = allowEmptyCollections;
        }
        public bool CanResolve(
            CreationContext        context,
            ISubDependencyResolver contextHandlerResolver,
            ComponentModel         model,
            DependencyModel        dependency
        ) {
            if (dependency.TargetType == null) return false;
            var itemType = dependency.TargetType.GetCompatibileArrayItemType();
            if (itemType == null) return false;
            if (!allowEmptyCollections)
            {
                return GetOtherHandlers(itemType, model.Name).Any();
            }
            return true;
        }
        public object Resolve(
            CreationContext        context,
            ISubDependencyResolver contextHandlerResolver,
            ComponentModel         model,
            DependencyModel        dependency
        ) {
            var itemType = dependency.TargetType.GetCompatibileArrayItemType();
            var handlers = GetOtherHandlers(itemType, model.Name);
            var resolved = handlers
                .Select(h => kernel.Resolve(h.ComponentModel.Name, itemType))
                .ToArray();
            var components = Array.CreateInstance(itemType, resolved.Length);
            resolved.CopyTo(components, 0);
            return components;
        }
        private IEnumerable<IHandler> GetOtherHandlers(
            Type   serviceType,
            string thisComponentName
        ) {
            return kernel
                .GetHandlers(serviceType)
                .Where(h => h.ComponentModel.Name != thisComponentName);
        }
    }
