    public TestPage()
    {
        this.InitializeComponent();
        this.PointerPressed += TestPage_PointerPressed;
        FFlipView.PointerPressed += FFlipView_PointerPressed;
    }
    
    private void FFlipView_PointerPressed(object sender, PointerRoutedEventArgs e)
    {
        e.Handled = true;
    }
    
    private void TestPage_PointerPressed(object sender, PointerRoutedEventArgs e)
    {
        
    }
