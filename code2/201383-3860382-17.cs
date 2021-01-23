    public static void PrependText(this TextBoxBase textBox, string text)
    {
        if (text.Length > 0)
        {
            var start = textBox.SelectionStart;
            var length = textBox.SelectionLength;
            try
            {
                textBox.Select(0, 0);
                textBox.SelectedText = text;
            }
            finally
            {
                if (textBox.Width == 0 || textBox.Height == 0)
                    textBox.Select(start, length);
            }
        }
    }
