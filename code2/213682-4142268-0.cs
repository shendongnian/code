    private void AddUser_Click(object sender, RoutedEventArgs e)
    {
        Button button = sender as Button;
        Grid parentGrid = GetVisualParent<Grid>(button);
        List<TextBox> textBoxes = GetVisualChildCollection<TextBox>(parentGrid);
        foreach (TextBox textBox in textBoxes)
        {
            if (textBox.Tag == "Number")
            {
                // Do something..
            }
            else if (textBox.Tag == "Login")
            {
                // Do something..
            }
            else if (textBox.Tag == "Password")
            {
                // Do something..
            }
        }
    }
