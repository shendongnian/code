    private void copy_Click(object sender, EventArgs e)
    {
        if (!string.IsNullOrEmpty(convertedText.Text))
        {
            Clipboard.SetText(convertedText.Text);
            convertedText.Text = Clipboard.GetText();
        }
    }
