        // gridRef1v doesn't exist
        if (cbGridRef1.SelectedValue != null)
        {
            string gridRef1V = cbGridRef1.SelectedValue.ToString();
        }  //gridRef1V no longer available after this } 
        else
        {
            // gridRef1v doesn't exist
            MessageBox.Show("The grid ref1 field must contain a value");
            cbGridRef1.Focus();
        }
        // gridRef1v doesn't exist
