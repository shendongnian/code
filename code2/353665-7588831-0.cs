     private void buttonInsert_Click(object sender, EventArgs e)
     {
       int result = CreateCustomer(textBoxName.Text.Trim(),
                                   textBoxContactNo.Text.Trim(),
                                   textBoxAddress.Text.Trim());
        if (result > 0)
        {
           foreach(var row in recordsDataGridView.Rows)
           {
               CreateLineItem(quantity, particulars, rates);
           }
        }
