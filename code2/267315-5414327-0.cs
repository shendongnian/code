    void button_Click(object sender, EventArgs e)
    {
        var message = "Yes or No?";
        var title = "Hey!";
        var result = MessageBox.Show(
            message,                  // the message to show
            title,                    // the title for the dialog box
            MessageBoxButtons.YesNo,  // show two buttons: Yes and No
            MessageBoxIcon.Question); // show a question mark icon
        // the following can be handled as if/else statements as well
        switch (result)
        {
        case DialogResult.Yes:   // Yes button pressed
            MessageBox.Show("You pressed Yes!");
            break;
        case DialogResult.No:    // No button pressed
            MessageBox.Show("You pressed No!");
            break;
        default:                 // Neither Yes nor No pressed (just in case)
            MessageBox.Show("What did you press?");
            break;
        }
    }
