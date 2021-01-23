    DialogResult result = MessageBox.Show("this item is already in the system, do you want to add it anyway ?", "Question",MessageBoxButtons.YesNoCancel);
    if (result == DialogResult.Yes)
    {
        // they clicked Yes
    }
    else if (result == DialogResult.No)
    {
        // they clicked No
    }
    else
    {
        // they clicked Cancel
    }
