    private void UpdateUI()
    {
        bool isNewRecord = (contact.ContactId == 0);
        
        statusLabel.Text = isNewRecord ? "Create New Contact" : "Edit " + contact.Name;
        nameTextBox.Visible = isNewRecord;
        
        bool isBusiness = contactTypeBusinessRadioButton.IsChecked;
        
        spouseCheckBox.Visible = !isBusiness;
        bool hasSpouse = !isBusiness & spouseCheckBox.IsChecked;
        spouseNameTextBox.Visible = hasSpouse;
    }
