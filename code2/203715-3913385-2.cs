        if (dataListBox.Items.Count != 0)
        {
            MessageBox.Show("Please add at least one item to the list.", "List Box is empty", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        else
        {
            try
            {
                this.save();
            }
            catch(Exception ex)
            {
                 MessageBox.Show("Saving failed.\n Technical details:\n" + ex.Message, "Saving Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
