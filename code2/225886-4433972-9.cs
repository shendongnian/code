    private void Button_Loaded(object sender, RoutedEventArgs e)
    {
        Button button = sender as Button;
        object buttonChrome = VisualTreeHelper.GetChild(button, 0);
        PropertyInfo renderMouseOverInfo = buttonChrome.GetType().GetProperty("RenderMouseOver");
        if (renderMouseOverInfo != null)
        {
            renderMouseOverInfo.SetValue(buttonChrome, false, null);
        }
    }
