    void UpdatePartsOfTheUI() {
        // Do something here
        if(myListBox.Items.Count == 0) {
            myLabel.Text = "You must choose some files!";
        } else {
            myLabel.Text = String.Empty;
        }
    }
    
    /* ... */
    
    void myButton_Click(object sender, EventArgs e) {
        if(myListBox.SelectedIndex > -1) {
            // Remove the item
            myListBox.Items.RemoveAt(myListBox.SelectedIndex);
    
            // Update the UI
            UpdatePartsOfTheUI();
        }
    }
