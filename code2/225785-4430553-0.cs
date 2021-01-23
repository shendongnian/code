    UserControl1.Changed += UserControl1_Changed;
---
    // A delegate type for hooking up change notifications.
    public delegate void ChangedEventHandler(object sender, EventArgs e);
    //the actual event
    public event ChangedEventHandler Changed;
    // Method to raise/fire the Changed event. Call this whenever something changes
    protected virtual void OnChanged(EventArgs e) 
    {
        if (Changed != null)
           Changed(this, e);
    }
    public StringParameterControl(string aName, string aValue)
        : base(aName)
    {
        InitializeComponent();
        txtValue.Text = aValue;
    }
    public StringParameterControl(string aName)
        : base(aName)
    {
        InitializeComponent();
    }
    public StringParameterControl()
        : base()
    {
        InitializeComponent();
    }
    public void SetValue(string aValue)
    {
        txtValue.Text = aValue;
        OnChanged(EventArgs.Empty);
    }
    public override object GetValue()
    {
        return txtValue.Text;
    }
