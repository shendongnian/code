    public partial class MainPage
    {
    
    		
        public static readonly DependencyProperty TitleProperty;
        public string Title
        {
    		get { return (string)GetValue(TitleProperty); }
	        set { SetValue(TitleProperty, value); }
        }
		static MainPage()
		{
			TitleProperty= DependencyProperty.Register(
				"Title",
				typeof(string),
				typeof(MainPage));
		}
		public MainPage()
		{
			InitializeComponent();
			Title = "Test";
		}
    }
