        private Binding _activeBinding;
        private TextBox _activeTextbox;
        private TextBox ActiveTextBox
        {
            get { return _activeTextbox; }
            set
            {
                // Check if a binding exists, initialize if one does not
                if (_activeBinding == null)
                {
                    _activeBinding = new Binding("Value");
                    _activeBinding.Source = this.sld;
                }
                if (_activeTextbox != null)
                {
                    // Clear the binding
                    BindingOperations.ClearBinding(_activeTextbox, TextBox.TextProperty);
                }
                _activeTextbox = value;
                if (_activeTextbox != null)
                {
                    // Set the new binding
                    _activeTextbox.SetBinding(TextBox.TextProperty, _activeBinding);
                }
            }
        }
        
        private void TextBox_GotFocus(object sender, RoutedEventArgs e)
        {
            this.ActiveTextBox = sender as TextBox;
        }
