    string gridRef1V;
    if (cbGridRef1.SelectedValue != null)
            {
                gridRef1V = cbGridRef1.SelectedValue.ToString();
            }
            else
            {
                MessageBox.Show("The grid ref1 field must contain a value");
                cbGridRef1.Focus();
            }
