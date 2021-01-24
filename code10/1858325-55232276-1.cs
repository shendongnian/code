    private void btnSave_Click(object sender, RoutedEventArgs e)
    {
        tbFirstName.GetBindingExpression(TextBox.TextProperty).UpdateSource();
        tbLastName.GetBindingExpression(TextBox.TextProperty).UpdateSource();
    }
