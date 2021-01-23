    private void ValidateName()
    {
     if (string.IsNullOrEmpty(NameTextBox.Text))
        {
                //Validation failed, so set an appropriate error message
                errorProvider.SetError(NameTextBox, "You must enter your name");
        }
        else
        {
                //Clear previous error message
                errorProvider.SetError(NameTextBox, string.Empty);
        }
    }
