    TextBox txt1 = new TextBox();
    TextBox txt2 = new TextBox();
    public Window1()
    {
       InitializeComponent();
       txt1.Name = "txt1";
       txt1.Margin = new Thickness(30, 0, 128, 0);
       txt1.VerticalAlignment = VerticalAlignment.Top;
       txt1.Visibility = Visibility.Visible;
       txt2.Name = "txt2";
       txt2.Margin = new Thickness(30, 32, 128, 0);
       txt2.VerticalAlignment = VerticalAlignment.Top;
       Binding binding = new Binding();
       binding.Source = txt1; // set the source object instead of ElementName
       binding.Path = new PropertyPath(TextBox.VisibilityProperty);
       BindingOperations.SetBinding(txt2, TextBox.VisibilityProperty, binding);
       grid.Children.Add(txt1);
       grid.Children.Add(txt2);
    }
