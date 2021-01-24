     InitializeComponent();
     var binding = new Binding
     {
        Source = this,
        Path = new PropertyPath("MyProp")
     };
     // Bind to the textbox
     BindingOperations.SetBinding(tb, TextBox.TextProperty, binding);
     
     // The property definition
     public string MyProp { get; set; } = "test";
