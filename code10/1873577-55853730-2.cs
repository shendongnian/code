    private void RadioButton_Unchecked(object sender, RoutedEventArgs e)
    {
        var button = sender as RadioButton;
        dynamic model = _models[button];
        try
        {
            model.Edited = true;
        }
        catch { }
    }
