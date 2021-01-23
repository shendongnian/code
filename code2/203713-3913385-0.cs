    try
    {
    //when you go to save, and the list box is empty, you should get an error message
        if (dataListBox.Items.Count != 0)
            throw new Exception("Please add at least one item to the list.");
        this.save();
    }
    catch (Exception err)
    {
        //spits out the errors if there are any
        MessageBox.Show(err.Message, "List Box is empty", MessageBoxButtons.OK, MessageBoxIcon.Error);
    }
