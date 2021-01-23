    private void TextBox_MouseMove(object sender, MouseEventArgs e)
    {
        TextBox textBox = sender as TextBox;
        Point mousePoint = Mouse.GetPosition(textBox);
        int charPosition = textBox.GetCharacterIndexFromPoint(mousePoint, true);
        if (charPosition > 0)
        {
            char selectedChar = textBox.Text[charPosition];
            Debug.WriteLine(selectedChar);
        }
    }
