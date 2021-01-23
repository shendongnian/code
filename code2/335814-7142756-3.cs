    public MainPage()
    {
        InitializeComponent();
    
        _testSubject.DataContext = new Test();
        _test2Subject.DataContext = new Test();
    
    }
    
    private void Button_Click(object sender, RoutedEventArgs e)
    {
        ((Test)_testSubject.DataContext).State = "State2";
        ((Test)_test2Subject.DataContext).State = "State2"; 
    }
