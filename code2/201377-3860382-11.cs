    public static void PrependText(this TextBoxBase textBox, string text)
    {
        if (text.Length > 0)
        {
            int start;
            int length;
            textBox.GetSelectionStartAndLength(out start, out length);
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
