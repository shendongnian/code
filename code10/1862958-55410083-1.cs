        private void RichTextBox1_OnTextChanged(object sender, TextChangedEventArgs e)
        {
            var textRange = new TextRange(RichTextBox1.Document.ContentStart,RichTextBox1.Document.ContentEnd);
            var text = textRange.Text;
            if (string.IsNullOrEmpty(text.Trim()))
                return;
            if (!_loaded)
            {
                _orginalContent = text;
                _loaded = true;
            }
            var newContent = text;
            if (newContent == _orginalContent)
                UndoTextBlock.Foreground = Brushes.Gray;
            else
                UndoTextBlock.Foreground = Brushes.Green;
        }
