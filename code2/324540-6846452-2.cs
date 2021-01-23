    public partial class MainPage : PhoneApplicationPage
    {
    	private ObservableCollection<Schedule> _schedules;
    
    	public MainPage()
    	{
    		InitializeComponent();
    
    		string[] timeSplit = new string[] { "One1", "Two2", "Three3" };
    		string[] titleSplit = new string[] { "Title1", "Title2", "Title3" };
    		string[] categorySplit = new string[] { "Priority", "Favourite", "Another" };
    
    		_schedules = new ObservableCollection<Schedule>();
    
    		for ( int i = 0; i < timeSplit.Length; i++ )
    		{
    			_schedules.Add( CreateSchedule( timeSplit[i], titleSplit[i], categorySplit[i] ) );
    		}
    
    		scheduleListBox.ItemsSource = _schedules;
    	}
    
    	private Schedule CreateSchedule( string time, string title, string category )
    	{
    		Schedule schedule = new Schedule
    		{
    			Time = time,
    			Title = title,
    			Category = category
    		};
    
    		if ( category == "Priority" )
    		{
    			schedule.ImageSource = "/AlarmClock;component/Images/exclamination_mark.png";
    		}
    		else if ( category == "Favourite" )
    		{
    			schedule.ImageSource = "/AlarmClock;component/Images/star_full.png";
    		}
    
    		return schedule;
    	}
    }
    
    public class Schedule
    {
    	public string Time { get; set; }
    	public string Title { get; set; }
    	public string Category { get; set; }
    	public string ImageSource { get; set; }
    }
