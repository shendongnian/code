    public class ViewModelLocator
    {
        public static UnityContainer Contaner { get; private set;}
    	
    	static ViewModelLocator()
    	{
    		Container = new UnityContainer();
    		
    		Container.RegisterType<ProductListViewModel>(new ContainerControlledLifetimeManager());
    	}
    	
    	public ProductListViewModel ProductViewModel
    	{
    		get
    		{
    			return Container.Resolve<ProductListViewModel>();
    		}
    	}
    }
