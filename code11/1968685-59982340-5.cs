    private bool ValidateTextBoxes()
    {
        if (string.IsNullOrEmpty(textBox1.Text) || string.IsNullOrEmpty(textBox2.Text)
                || string.IsNullOrEmpty(textBox3.Text))
        {
           return false;
        }
        //Any other validation you may want... e.g length, regex pattern etc.
        return true;
    }
