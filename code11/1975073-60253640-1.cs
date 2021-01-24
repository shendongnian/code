      public MainWindow()
      {
         InitializeComponent();
    
         var binding = new Binding
         {
            Source = this,
            Path = new PropertyPath("MyProp"),
            Mode = BindingMode.TwoWay
         };
         // Bind to the textbox
         BindingOperations.SetBinding(tb, TextBox.TextProperty, binding);
      }     
      // The property definition
      public string MyProp { get; set; } = "test";
