    private async void txt_Barcode_TextChanged(object sender, EventArgs e)
    {
        await Task.Delay(1000);
        con.Open();
        GenerateInvoice gn = new GenerateInvoice();
        string query = "SELECT * FROM dbo.Inventory WHERE Barcode = '" + txt_Barcode.Text + "' ";
        SqlCommand cmd = new SqlCommand(query, con);
        SqlDataReader dr = cmd.ExecuteReader();
        while (DR1.Read())
        {
            gn.txt_Barcode.Text = dr["Barcode"].ToString();
            gn.txt_ProductName.Text = dr["ProductName"].ToString();
            gn.txt_Price.Text = dr["SellingPrice"].ToString();
            gn.txt_QTY.Text = 1.ToString();
            gn.txt_Total.Text = dr["SellingPrice"].ToString();
        }
        con.Close();
    }
