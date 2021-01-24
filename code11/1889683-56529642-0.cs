    public class MainActivity : AppCompatActivity, BottomNavigationView.IOnNavigationItemSelectedListener 
    {
        public static Dictionary<string, Fragment> FragmentList { get; set; }
        private Fragment currentFragment = null;
    	private BottomNavigationView navigation;
      
    	protected override void OnCreate(Bundle savedInstanceState)
    	{
    		base.OnCreate(savedInstanceState);
    		SetContentView(Resource.Layout.layout_mainactivity);
    
    		// create our fragments and initialise them early.
    		if (FragmentList == null)
    		{
    			FragmentList = new Dictionary<string, Fragment>
    			{
    				{ "main", MainFragment.NewInstance() },
    				{ "bugreport", BugReportFragment.NewInstance() },
    				{ "settings", SettingsFragment.NewInstance() }
    			};
    		}
    
    		navigation = FindViewById<BottomNavigationView>(Resource.Id.bottom_nav);
    		navigation.SetOnNavigationItemSelectedListener(this);
    		navigation.SelectedItemId = Resource.Id.navigation_main;
    	}
    
    	 public bool OnNavigationItemSelected(IMenuItem item)
    	{
    		if (!popAction)
    		{
    			navigationResourceStack.Push(item.ItemId);
    		}
    
    		switch (item.ItemId)
    		{
    			case Resource.Id.navigation_main:
    				currentFragment = FragmentList["main"];
    				break;
    			case Resource.Id.navigation_settings:
    				currentFragment = FragmentList["settings"];
    				break;
    			case Resource.Id.navigation_bugreport:
    				currentFragment = FragmentList["bugreport"];
    				break;
    		}
    
    		if (currentFragment == null)
    		{
    			return false;
    		}
    		else
    		{
    			FragmentManager.BeginTransaction().Replace(Resource.Id.frame_content, currentFragment).Commit();
    			return true;
    		}
    	}	
    }
