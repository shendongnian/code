    private static UavControlForm _instance = new UavControlForm();
    private UavControlForm()
    {
        InitializeComponent();   
    }
    public static UavControlForm Instance
    {
        get { return _instance; }
    }
    public ListBox FlightUavListBox
    {
        get { return lsbFlightUavs; }
    }
