    public ObservableCollection<Element> TopLevelElements = new ObservableCollection<Element>();
    
    public MainWindow() 
    {
    	TopLevelElements.Add(new Element("filename"));
    	
    	DataContext = this;
    	
    	InitializeComponent();
    }
