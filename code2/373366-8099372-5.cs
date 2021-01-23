    public MainPage() {
      InitializeComponent();
      for (int rowCounter = 0; rowCounter < 3; rowCounter++) {
        for (int colCounter = 0; colCounter < 3; colCounter++) {
          var codeButton = new Button();
          Grid.SetRow(codeButton, rowCounter);
          Grid.SetColumn(codeButton, colCounter);
          codeButton.Click += new RoutedEventHandler(AllButtons_Click);
          gameboardGrid.Children.Add(codeButton);
        }
      }
    }  
