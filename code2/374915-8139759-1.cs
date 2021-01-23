    private void m_MeasurementName_PreviewKeyDown(object sender, KeyEventArgs e)
    {
        var tb = (sender as TextBox);
        if (Keyboard.Modifiers == ModifierKeys.Alt && Keyboard.IsKeyDown(Key.Enter))
        {
            tb.Text += "\r\n";
            tb.SelectionStart = tb.Text.Length;
            e.Handled = true;
        }
        else if (Keyboard.IsKeyDown(Key.Enter))
        {
            var textBinding = BindingOperations.GetBindingExpression(
                tb, TextBox.TextProperty);
    
            if (textBinding != null)
                textBinding.UpdateSource();
            e.Handled = true;
        }
    }
