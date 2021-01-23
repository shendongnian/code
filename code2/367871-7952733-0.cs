    void Main()
    {
    	AllJobs = new ObservableCollection<Job>();
    	AllJobs.Add(new Job());
    }
    
    public class Job { }
    
    private ObservableCollection<Job> allJobs;
    
    public ObservableCollection<Job> AllJobs
    {
    	get
    	{
    		return this.allJobs;
    	}
    	set
    	{
    		this.allJobs = value;
    	}
    }
