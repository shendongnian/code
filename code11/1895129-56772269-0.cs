    public ObservableCollection<YourModel> Collection { get; private set; }    
    class Window() {
        Collection = GetYourData();
        InitializeComponent();
    }
