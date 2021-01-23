            if (dataGridView.IsHandleCreated && e.ColumnIndex == buyColumn.Index)
            {
                double openprice = (double)dataGridView.Rows[e.RowIndex].Cells[offerColumn.Index].Value;
                string symbol = dataGridView.Rows[e.RowIndex].Cells[symbolColumn.Index].Value.ToString();
                double quanity= (double)dataGridView.Rows[e.RowIndex].Cells[quanityColumn.Index].Value;
                MessageBox.Show("I buy " + symbol +  " with "  + quanity + " at " + openprice);
             } 
