    void Main()
    {
    	PresentationManager.Instance.AllJobs.Add(new Job());
    }
    
    public class Job { }
    
    sealed class PresentationManager 
    { 
    	public static readonly PresentationManager Instance = new PresentationManager(); 
    	
    	private PresentationManager()
    	{
    		allJobs = new ObservableCollection<Job>();
    	}
    	
    	private ObservableCollection<Job> allJobs; 
    	public ObservableCollection<Job> AllJobs 
    	{ 
    		get { return this.allJobs; } 
    		set { this.allJobs = value; } 
    	} 
    }
