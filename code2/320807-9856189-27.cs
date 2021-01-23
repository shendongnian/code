        private void TextBuffer_Changed(object sender, TextContentChangedEventArgs e)
        {
            if (!_isChangingText)
            {
                _isChangingText = true;
                FormatCode(e);
            }
        }
