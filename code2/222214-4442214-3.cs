    public NoteView()
    {
        InitializeComponent();
        DependencyPropertyDescriptor dpd = 
            DependencyPropertyDescriptor.FromProperty(UserControl.DataContextProperty, 
                                                      typeof(UserControl));
        if (dpd != null)
        {
            dpd.AddValueChanged(this, new EventHandler(DataContextChangedHandler));
        }
    }
    void DataContextChangedHandler(object sender, EventArgs e)
    {
        MessageBox.Show("DataContext Changed: " + DataContext);
    }
