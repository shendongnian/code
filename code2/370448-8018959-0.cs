    // Put this after the InitializeComponent() call in the constructor.
    txtDisplay.TextChanged += HandleTextBoxTextChanged;
    ...
    private void HandleTextBoxTextChanged(object sender, EventArgs e)
    {
        bool gotText = txtDisplay.Text.Length > 0;
        menuSaveButton.Enabled = gotText;
    }
