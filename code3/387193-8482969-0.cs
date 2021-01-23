     var pd = DependencyPropertyDescriptor.FromProperty(TextBox.TextProperty, typeof(TextBox));
     pd.AddValueChanged(myTextBox, OnTextChanged);
    
     private void OnTextChanged(object sender, EventArgs e)
     {
         ...
     }
