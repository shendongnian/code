    private void IntegerTextBox_TextChanged(object sender, EventArgs e)
    {
        for (int i = 0; i < Text.Length; i++)
        {
            int c = Text[i];
            if (c < '0' || c > '9')
            {
               Text = Text.Remove(i, 1);
             }
        }
    }
