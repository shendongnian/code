    public class Controller
    {
    	private readonly View view;
    
    	public Controller(ViewModule viewModule)
    	{
    		using (IKernel kernel = new StandardKernel(viewModule))
    		{
    			this.view = kernel.Get<View>(new ConstructorArgument("controller", this);
    		}
    	}
    }
