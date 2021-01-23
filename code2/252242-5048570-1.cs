    private void Button_Loaded(object sender, RoutedEventArgs e)
    {
        Button button = sender as Button;
        Binding binding = new Binding();
        binding.Source = LayoutRoot;
        binding.Path = new PropertyPath("DataContext.JUNK");
        button.SetBinding(Button.ContentProperty, binding);
    }
