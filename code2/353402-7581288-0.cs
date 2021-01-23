    public event EventHandler TextChanged
    {
        add { customTextBox.TextChanged += value; }
        remove { customTextBox.TextChanged -= value; }
    }
