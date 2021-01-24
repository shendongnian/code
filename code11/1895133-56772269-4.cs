    public ObservableCollection<YourModel> Collection { get; private set; }    
    public Window() {
        Collection = GetYourData();
        InitializeComponent();
    }
