    public override void OnApplyTemplate()
    {
        Button button = GetTemplateChild("btnHeader") as Button;
        button.Click += Button_Click;
    }
    private void Button_Click(object sender, RoutedEventArgs e)
    {
        MessageBox.Show("button clicked!");
    }
