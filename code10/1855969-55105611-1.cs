    	public class ControllersInstaller : IWindsorInstaller
    	{
    		public void Install(IWindsorContainer container, IConfigurationStore store)
    		{
    			container.Register(AllTypes.FromThisAssembly()
    				.Pick().If(t => t.Name.EndsWith("Controller"))
    				.Configure(configurer => configurer.Named(configurer.Implementation.Name))
    				.LifestylePerWebRequest());
    		}
    	} 
