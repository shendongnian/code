    public class TaskResolverAttribute : Attribute
    {
        public Type ResolverType { get; private set; }
        public TaskResolverAttribute(Type resolverType)
        {
            if (!typeof(ITaskResolver).IsAssignableFrom(resolverType))
                throw new ArgumentException("resolverType must implement ITaskResolver");
            ResolverType = resolverType;
        }
    }
    public class MyTaskResolver : ITaskResolver
    {
    }
    [TaskResolver(typeof(MyTaskResolver))]
    public class MyTask
    {
    }
    public static class TaskResolverFactory
    {
        public static ITaskResolver GetForType(Type taskType)
        {
            var attribute =
                Attribute.GetCustomAttribute(taskType, typeof(TaskResolverAttribute)) as TaskResolverAttribute;
            if (attribute == null)
                throw new ArgumentException("Task does not have an associated TaskResolver");
            return (ITaskResolver)Activator.CreateInstance(attribute.ResolverType);
        }
    }
