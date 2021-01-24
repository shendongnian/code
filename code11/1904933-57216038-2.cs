    // Create an instance of metodosEmpenho in your activity and pass through the Activity as a parameter to the constructor.
    
    public class MyActivity : Activity
    {
    	private MetodosEmpenho metodosEmpenho;
    	
    	protected override void OnCreate (Bundle savedInstanceState)
    	{
    		base.OnCreate (savedInstanceState);
    
    		// Set our view from the "main" layout resource
    		SetContentView (Resource.Layout.Main);
    
    		metodosEmpenho = new MetodosEmpenho(Activity);
    		metodosEmpenho.VerOperador("");
    	}
    }
    
    // Create a consturctor in the MetodosEmpenho class that will take the Activity paramter and store it for later use.
    
    public class MetodosEmpenho
    {
    	private readonly Activity _activity
    
    	public MetodosEmpenho(Activity currActivity)
    	{
    		_activity = currActivity;
    	}
    	
    	public async void PegaValor(bool retry)
    	{
    		_activity.RunOnUiThread(async () => {
        		await PopupNavigation.PushAsync(new Paginas.PopupTentarNovamente());
        	});
    
    		Paginas.PopupTentarNovamente tentarNovamente = new Paginas.PopupTentarNovamente();
    		if (tentarNovamente.resultado)
    		{
    			retry = false;
    		}
    		else
    		{
    			retry = true;
    		}
        }
    }
