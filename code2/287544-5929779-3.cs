    public MainWindow()
    {
      InitializeComponent();
      for (int i = 0; i < 10; ++i)
      {
        Button button = new Button()
          { 
            Content = string.Format("Button for {0}", i),
            Tag = i
          };
        button.Click += new RoutedEventHandler(button_Click);
        this.grid.Children.Add(button);
      }
    }
    void button_Click(object sender, RoutedEventArgs e)
    {
      Console.WriteLine(string.Format("You clicked on the {0}. button.", (sender as Button).Tag));
    }
