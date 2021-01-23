    class Program
    {
        static void Main()
        {
    	SiteStructure s = SiteStructure.Instance;
        }
    }
    
    public sealed class SiteStructure
    {
        static readonly SiteStructure _instance = new SiteStructure();
        public static SiteStructure Instance
        {
    	get
    	{
    	    return _instance;
    	}
        }
        SiteStructure()
        {
    	// Initialize.
        }
    }
