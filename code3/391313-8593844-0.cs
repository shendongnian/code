    private void dataBaseSaveButton_Click(object sender, EventArgs e)
    {
        if (firstNameTextBox.Text.Equals(string.Empty) || lastNameTextBox.Text.Equals(string.Empty) || payTextBox.Text.Equals(string.Empty))
        {
            MessageBox.Show("Please fill out all of the fields.", "Fields Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
        else
        {
            //This is where I am saving the data to a file using StreamWrriter.
            this.IgnoreCloseEvent = true;
            this.Close();
            this.IgnoreCloseEvent = false;
        }
