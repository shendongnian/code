public interface IaDataService
{
	void SomeProcessing(object obj);
}
public class DataService : IaDataService
{
	public void SomeProcessing(object obj)
	{
	}
}
We could do something like:
var containerBuilder = new ContainerBuilder();
containerBuilder.RegisterType<DataService>()
	.As<IaDataService>();
var container = containerBuilder.Build();
var items = new List<object>{"abc", 123};
Parallel.ForEach(items, item =>
{
	// Note I'm calling container.BeginLifetimeScope() inside the ForEach
	using (var parallelScope = container.BeginLifetimeScope())
	{
		var aDataService = parallelScope.Resolve<IaDataService>();
		aDataService.SomeProcessing(item);
	}
});
Using WebForms, you're likely better off using the specific integration for it:
[Autofac WebForms][1], and there are other best practice questions about thread safety, generating new scopes for each item you generate etc. But the above should be enough to get started.
  [1]: https://autofaccn.readthedocs.io/en/latest/integration/webforms.html
