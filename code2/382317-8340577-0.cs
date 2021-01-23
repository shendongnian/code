    private void Something_Changed(object sender, EventArgs e)
    {
        createButton.Enabled = 
            !String.IsNullOrEmpty(firstNameText.Text) &&
            !String.IsNullOrEmpty(lastNameText.Text) &&
            !String.IsNullOrEmpty(descriptionText.Text);
    }
