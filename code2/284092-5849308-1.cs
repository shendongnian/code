    public partial class MainPage : PhoneApplicationPage{
	     public List<RssFeed> MyPivots { get; set; }
	    // Constructor
	    public MainPage()
	    {
		MyPivots = new List<RssFeed>
		{
			new RssFeed{ MyTitle = "Title1", YourRssText = "Body1"},
			new RssFeed{ MyTitle = "Title2", YourRssText = "Body2"},
			new RssFeed{ MyTitle = "Title3", YourRssText = "Body3"},
		};
		InitializeComponent();
		this.DataContext = this;
	     }
    }
    public class RssFeed   
    {	
       public string MyTitle { get; set; }
       public string YourRssText { get; set; }
     }
