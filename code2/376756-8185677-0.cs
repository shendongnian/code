    private void TextBox_PreviewKeyDown(object sender, KeyEventArgs e)
    {
        if (e.Key == Key.Enter)
        {
            var obj = sender as UIElement;
            BindingExpression textBinding = BindingOperations.GetBindingExpression(
                obj, TextBox.TextProperty);
            if (textBinding != null)
                textBinding.UpdateSource();
        }
    }
