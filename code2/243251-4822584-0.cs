    private void OnTextChanged(object sender, EventArgs args)
    {
        UpdateUserInterface();
    }
    
    private void UpdateUserInterface()
    {
        this.myButton.Enabled = !string.IsNullOrWhiteSpace(this.textBox1.Text) &&
                                !string.IsNullOrWhiteSpace(this.textBox2.Text);
    }
