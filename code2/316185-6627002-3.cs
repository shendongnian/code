    public class ControllersInstaller : IWindsorInstaller
    {
    	#region IWindsorInstaller Members
    
    	public void Install(IWindsorContainer container, IConfigurationStore store)
    	{
    		container.Register(Component.For<WpRegistration.Web.Filters.AgencyAuthorize>().LifeStyle.Transient);
    		container.Register(Component.For<IActionInvoker>().ImplementedBy<WindsorExtensions.Mvc.WindsorActionInvoker>().LifeStyle.Transient);
    		
    		container.Register(AllTypes.FromThisAssembly()
    							.BasedOn<IController>()
    							.If(Component.IsInSameNamespaceAs<HomeController>())
    							.If(t => t.Name.EndsWith("Controller"))
    							.Configure((c => c.LifeStyle.Transient)));
    	}
    
    	#endregion
    }
