    private void ComboBox_Loaded(object sender, RoutedEventArgs e)
    {
        ((ComboBox)sender).GetBindingExpression(ComboBox.ItemsSourceProperty)
                          .UpdateTarget();
    }
