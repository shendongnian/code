    void buttonAdd_Click(object sender, EventArgs e)
    {
        if (string.IsNullOrWhiteSpace(textBoxField.Text))
        {
             // Show message?
             MessageBox.Show(....);
             return; // Don't process
        }
        // Field has a value, do your thing here...
    }
