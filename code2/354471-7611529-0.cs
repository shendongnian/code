    public MainWindow()
    {
      InitializeComponent();
      DistSlider.ValueChanged +=new RoutedPropertyChangedEventHandler<double>(DistSlider_ValueChanged);
    }
    
    private void DistSlider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
    {
        DistTextBlock.Text = DistSlider.Value.ToString();
    }
