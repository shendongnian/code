    public ParentWindow()
    {
        InitializeComponent();
    }
    private void testButton_Click(object sender, RoutedEventArgs e)
    {
        TutorialWindow tutorialWindow = new TutorialWindow(this);
        tutorialWindow.Show();
    }
    public void Window_MouseDown(object sender, MouseButtonEventArgs e)
    {
        // Do something
    }
