    public partial class FormManager : Form
    {
    	public FormManager()
    	{
    		InitializeComponent();
    	}
    
    	public Action BackgroundActionCompleted { get; set; }
    
    	public void OnBackgroundActionCompleted()
    	{
    		if (this.BackgroundActionCompleted != null)
    		{
    			// Invoke so the action will be launched on the UI thread
    			this.Invoke(this.BackgroundActionCompleted);
    		}
    	}
    }
