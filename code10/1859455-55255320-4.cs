    private void frminventory_FormClosing(object sender, FormClosingEventArgs e) {
      // Data has not been changed, just close without pesky questions
      if (!isEdited)
        return;
      // If it's a user who is closing the form...
      if (e.CloseReason == CloseReason.UserClosing) {
        var action = MessageBox.Show(
          "You've edited the data, do you want to save it?"
           Text, // Let user know which form asks her/him
           MessageBoxButtons.YesNoCancel);
        if (DialogResult.Yes == action)
          Save(); // "Yes" - save the data edited and close the form
        else if (DialogResult.No == action)
          ;       // "No"  - discard the edit and close the form
        else
          e.Cancel = true; // "Cancel" - do not close the form (keep on editing) 
      }
    }
