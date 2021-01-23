    bool flagTextChanged = true;
    private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
    {
      TextBox txt = sender as TextBox;
      if (flagTextChanged && txt != null)
      {
        flagTextChanged = false;
        Binding b = BindingOperations.GetBinding(txt, TextBox.TextProperty);
        if (b != null)
        {
          txt.ClearValue(TextBox.TextProperty);
          BindingOperations.SetBinding(txt, TextBox.TextProperty, b);
        }
        flagTextChanged = true;
      }
    }
