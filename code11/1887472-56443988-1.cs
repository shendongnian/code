 c#
builder.RegisterModule<TimeMeasuringResolveModule>();
TimeMeasuringResolveModule:
 c#
public class TimeMeasuringResolveModule : Module
{
	private readonly ResolveInfo _current;
	protected override void AttachToComponentRegistration(
		IComponentRegistry componentRegistry, IComponentRegistration registration)
	{
		registration.Preparing += Registration_Preparing;
		registration.Activating += Registration_Activating;
		base.AttachToComponentRegistration(componentRegistry, registration);
	}
	private void Registration_Preparing(object sender, PreparingEventArgs e)
	{
        // Called before resolving type
		_current = new ResolveInfo(e.Component.Activator.LimitType, _current);
	}
	private void Registration_Activating(object sender, ActivatingEventArgs<object> e)
	{
        // Called when type is constructed
		var current = _current;
		current.MarkComponentAsResolved();
		_current = current.Parent;
		if (current.Parent == null)
		{
			ResolveInfoVisualizer.VisualizeGraph(current);
		}
	}
}
ResolveInfo:
 c#
public sealed class ResolveInfo
{
	private Stopwatch _watch = Stopwatch.StartNew();
	public ResolveInfo(Type componentType, ResolveInfo parent)
	{
		ComponentType = componentType;
		Parent = parent;
		Dependencies = new List<ResolveInfo>(4);
		if (parent != null) parent.Dependencies.Add(this);
	}
	public Type ComponentType { get; }
	public List<ResolveInfo> Dependencies { get; }
	// Time it took to create the type including its dependencies
	public TimeSpan ResolveTime { get; private set; }
	// Time it took to create the type excluding its dependencies
	public TimeSpan CreationTime { get; private set; }
	public ResolveInfo Parent { get; }
	public void MarkComponentAsResolved()
	{
		ResolveTime = _watch.Elapsed;
		CreationTime = ResolveTime;
		foreach (var dependency in this.Dependencies)
		{
			CreationTime -= dependency.ResolveTime;
		}
	}
}
ResolveInfoVisualizer:
 c#
public static class ResolveInfoVisualizer
{
	public static void VisualizeGraph(ResolveInfo node, int depth = 0)
	{
		Debug.WriteLine(
			$"{new string(' ', depth * 3)}" +
			$"{node.ComponentType.FullName} " +
			$"({node.ResolveTime.TotalMilliseconds.ToString("F1")} ms. / " +
			$"/ {node.CreationTime.TotalMilliseconds.ToString("F1")} ms.));
		foreach (var dependency in node.Dependencies)
		{
			VisualizeGraph(dependency, depth + 1);
		}
	}
}
Instead of loging to the Debug Window, you should typically use the output in a unit test. Do note that this `TimeMeasuringResolveModule` is **NOT** thread-safe. Considering the performance overhead of this module, you should only use it as part of a single integration test.
Also note that although this module does generate object graphs, it does not output a representive object graph, but only consists of the objects that are actually activated during that resolve. Already initialized singletons, for instance, will not show up in the graph, as they are effectively no-ops. For visualizing truthful object graphs, a different method should be used.
