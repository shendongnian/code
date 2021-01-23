    bool ValidateText(string Text)
    {
        if (string.IsNullOrEmpty(Text))
        {
            MessageBox.Show("Please enter a value");
            return false;
        }
        return true;
    }
