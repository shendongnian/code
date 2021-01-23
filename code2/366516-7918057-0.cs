    public partial class MainView : Window
    {
        public MainView()
        {
            InitializeComponent();
        	this.Loaded += (s, e) =>
        	               	{
        	               		this.DataContext = new MainViewModel();
        	               	};
        }
    }
