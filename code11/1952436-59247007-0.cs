 c#
public class DebugResolveModule : Module
{
    private readonly ThreadLocal<ResolveInfo> _current = new ThreadLocal<ResolveInfo>();
    protected override void AttachToComponentRegistration(
        IComponentRegistry componentRegistry, IComponentRegistration registration)
    {
        registration.Preparing += Registration_Preparing;
        registration.Activating += Registration_Activating;
        base.AttachToComponentRegistration(componentRegistry, registration);
    }
    private void Registration_Preparing(object sender, PreparingEventArgs e)
    {
        _current.Value = new ResolveInfo(e.Component.Activator.LimitType, _current.Value);
    }
    private void Registration_Activating(object sender, ActivatingEventArgs<object> e)
    {
        var current = _current.Value;
        current.MarkComponentAsResolved();
        _current.Value = current.Parent;
        if (current.Parent == null)
        {
            VisualizeGraph(current);
            Debug.WriteLine(
                $"total resolve time: {current.ResolveTime.TotalMilliseconds} ms.");
        }
    }
    private static void VisualizeGraph(ResolveInfo node, int depth = 0)
    {
        for (int i = 0; i < depth; i++)
        {
            Debug.Write("   ");
        }
        Debug.Write(node.ComponentType);
        Debug.Write(" (");
        Debug.Write(node.ResolveTime.TotalMilliseconds.ToString("F1"));
        Debug.Write(" ms. / ");
        Debug.Write(node.CreationTime.TotalMilliseconds.ToString("F1"));
        Debug.Write(" ms.)");
        Debug.WriteLine("");
        foreach (var dependency in node.Dependencies)
        {
            VisualizeGraph(dependency, depth + 1);
        }
    }
    private sealed class ResolveInfo
    {
        private Stopwatch _watch = Stopwatch.StartNew();
        public ResolveInfo(Type componentType, ResolveInfo parent)
        {
            ComponentType = componentType;
            Parent = parent;
            Dependencies = new List<ResolveInfo>(4);
            if (parent != null)
            {
                parent.Dependencies.Add(this);
            }
        }
        public Type ComponentType { get; }
        // Time it took to create the type including its dependencies
        public TimeSpan ResolveTime { get; private set; }
        // Time it took to create the type excluding its dependencies
        public TimeSpan CreationTime { get; private set; }
        public ResolveInfo Parent { get; }
        public List<ResolveInfo> Dependencies { get; }
        public void MarkComponentAsResolved()
        {
            ResolveTime = _watch.Elapsed;
            CreationTime = ResolveTime;
            foreach (var dependency in this.Dependencies)
            {
                CreationTime -= dependency.ResolveTime;
            }
                
            _watch = null;
        }
    }
}
Do note that this does not exactly what you want, because it is a resolve tricker. This means that a `SingleInstance` is only resolved once, which means the next time you request the graph, you'll be missing the singletons. This wasn't a problem for me, because I used this code to detect slow-resolving parts of the object graphs.
This code might, however, still give you some ideas of how to do this.
