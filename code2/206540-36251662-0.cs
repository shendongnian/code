    Style VerticalCenterStyle = new Style();
    
    public MainWindow()
    {
      // This call is required by the designer.
      InitializeComponent();
    
      VerticalCenterStyle.Setters.Add(new Setter(VerticalAlignmentProperty, VerticalAlignment.Center));
    }
    
    private void DataGrid_AutoGeneratingColumn(object sender, DataGridAutoGeneratingColumnEventArgs e)
    {   
      if (e.Column is DataGridTextColumn) {
        ((DataGridTextColumn)e.Column).ElementStyle = VerticalCenterStyle;
      }
    }
