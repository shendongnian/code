    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
    
            Box2.Foreground = Brushes.Black;
            Box1.IsEnabled = false;
            Box2.IsEnabled = false;
    		Box1.IsEnabledChanged += new DependencyPropertyChangedEventHandler(label1_IsEnabledChanged);
        }
    	
    	void label1_IsEnabledChanged( object sender, DependencyPropertyChangedEventArgs e ) {
    		//Set the foreground you want here!
    	}
    
    }
