    private void QueryExitApplication()
    {
        // Show a message box, asking the user to confirm that they want to quit
        DialogResult result;
        result = MessageBox.Show("Do you really want to quit this application?",
                                 "Quit Application?",
                                 MessageBoxButtons.YesNo,
                                 MessageBoxIcon.Warning);
    
        // Check the returned value of the MessageBox.Show function
        // (this corresponds to the button clicked by the user)
        if (result == DialogResult.Yes)
        {
            // Close the form
            this.Close();
        }
    
        // Otherwise, they selected No (so do nothing)
    }
