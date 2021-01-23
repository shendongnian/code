        string gridRef1v;
        if (cbGridRef1.SelectedValue != null)
        {
           gridRef1V = cbGridRef1.SelectedValue.ToString();
        }  //gridRef1V still available after this } 
        else
        {
            // gridRef1v exists
            MessageBox.Show("The grid ref1 field must contain a value");
            cbGridRef1.Focus();
        }
        // gridRef1v exists
