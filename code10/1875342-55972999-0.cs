    enum GVColumns
    {
        //We make an enum for our GridView columns
        Id = 0,
        CustomerName,
        BillNum,
        SubTotal,
        Discount,
        GrandTotal,
        Credit,
        AddedDate,
        AddedBy
    }
    private void btnsubtootal_Click(object sender, EventArgs e)
    {
        decimal grandtotalByDate = 0;
        DateTime searchedDate = new DateTime();
    
        foreach (DataGridViewRow row in dgvPurchase.SelectedRows)
        {
            var txtDateAddedValue = row.Cells[(int)GVColumns.AddedDate].Value.ToString();
            searchedDate = DateTime.Parse(txtDateAddedValue); //get our "added_date" to search
        }
    
        foreach (DataGridViewRow row in dgvPurchase.Rows)
        {
            var txtGrandTotalValue = row.Cells[(int)GVColumns.GrandTotal].Value.ToString(); //"grand_total" cell value as string
            var txtDateAddedValue = row.Cells[(int)GVColumns.AddedDate].Value.ToString(); //"added_date" cell value as string
            var rowDateAddedValue = DateTime.Parse(txtDateAddedValue);
            
            //check if our dates match
            if (rowDateAddedValue.Date == searchedDate.Date)
            {
                //add "grand_total" values if dates match
                grandtotalByDate += decimal.Parse(txtGrandTotalValue);
            }
        }
    
        txtNetSales.Text = grandtotalByDate.ToString("N2");
    }
