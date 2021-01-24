    private void dgvPurchase_RowStateChanged(object sender, DataGridViewRowStateChangedEventArgs e)
    {
        if (e.StateChanged == DataGridViewElementStates.Selected)
        {
            var txtDateAddedValue = e.Row.Cells[(int)GVColumns.AddedDate].Value.ToString();
    
            DateTime searchedDate = DateTime.Parse(txtDateAddedValue);
            decimal grandtotalByDate = 0;
    
            foreach (DataGridViewRow row in dgvPurchase.Rows)
            {
                var txtDAV = row.Cells[(int)GVColumns.AddedDate].Value.ToString();
                var dateRow = DateTime.Parse(txtDAV);
    
                if (dateRow.Date == searchedDate.Date)
                {
                    var txtGrandTotalValue = row.Cells[(int)GVColumns.GrandTotal].Value.ToString();
                    grandtotalByDate += decimal.Parse(txtGrandTotalValue);
                }
            }
    
            lblTotalByDate.Text = grandtotalByDate.ToString("N2");
        }
    }
