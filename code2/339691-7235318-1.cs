    private void TextBox_MouseMove(object sender, MouseEventArgs e)
    {
        TextBox textBox = sender as TextBox;
        Point mousePoint = Mouse.GetPosition(textBox);
        int charPosition = textBox.GetCharacterIndexFromPoint(mousePoint, true);
        if (charPosition > 0)
        {
            textBox.Focus();
            int index = 0;
            int i = 0;
            string[] strings = textBox.Text.Split(' ');
            while (index + strings[i].Length < charPosition && i < strings.Length)
            {
                index += strings[i++].Length + 1;
            }
            textBox.Select(index, strings[i].Length);
        }
    }
