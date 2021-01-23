    private void ProjectnumberTextBox_KeyDown(object sender, KeyEventArgs e)
    {
        if (e.KeyCode == Keys.Escape)
        {
           ProjectnumberTextBox.ReadOnly = true;
           ProjectnumbermodifyButton.Visibility = Visibility.Hidden;
        }
    }
