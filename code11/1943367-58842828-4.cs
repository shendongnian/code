     private int _textBoxCounter = 0;
            private void TextBoxElement_OnInitialized(object sender, EventArgs e)
            {
                if (_textBoxCounter < MyListBox.Items.Count)
                {
                    Keyboard.Focus((IInputElement)sender);
                    _textBoxCounter++;
                }
    
            }
