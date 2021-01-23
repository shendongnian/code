    class MainTab : IScreenTab
    {
    
        // Store a map of scree name to screen object
        // You can also just use a List<IScreenTab> 
        private Dictionary<string, IScreenTab> m_OtherScreens;
                
        // Your implementation goes here
        public MainTab(){ }
	    public MainTab(List<IScreenTab> screenTabList){ }
        public AddTab(string screenName, IScreenTab screenTabObj){ }
               
    }
