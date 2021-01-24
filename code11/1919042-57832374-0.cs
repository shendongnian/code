        string prodCode = txtProductCode.Text;
        decimal qty = Convert.ToInt32(txtQty.Text);
        decimal price = Convert.ToInt32(txtPrice.Text);
        decimal total = qty*price;
        bool isRowExist = false;
        foreach (DataGridViewRow row in dataGridView1.Rows)
        {
            if (row.Cells[0].Value.ToString().Equals(prodCode))
            {
                var totalQty = Convert.ToInt32(row.Cells[1].Value.ToString()) + qty ;
                var updateTotal = Convert.ToInt32(row.Cells[3].Value.ToString()) + total  ;
                row.Cells[1].Value = totalQty;
                row.Cells[3].Value = total; 
                isRowExist = true
            }
        }
        if(!isRowExist)
            dt.Rows.Add(prodCode,qty,price,total);
