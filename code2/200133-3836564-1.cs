    void CheckTextBox(TextBox textBox)
    {
        if (textBox == null)
        {
            throw new ArgumentNullException("textBox");
        }
        if (string.IsNullOrEmpty(textBox.Text))
        {
            // Handle me
        }
    }
    void Validate()
    {
        CheckTextBox(this.FirstNameTextBox);
        CheckTextBox(this.AddressLine1TextBox);
        CheckTextBox(this.AddressLine2TextBox);
    }
