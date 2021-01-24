    protected void btnGet_Incidents(object sender, EventArgs e)
    {
        ListBox1.Items.Clear();
        GetInfoForSelectedCustomerID();
    }
    private void GetInfoForSelectedCustomerID()
    {
        //get row from AccessDataSource based on value in dropdownlist
        DataView customersTable = (DataView)SqlDataSource2.Select(DataSourceSelectArguments.Empty);
        customersTable.RowFilter = "CustomerId = '" + TextBox1.Text + "'";
        DataRowView row = (DataRowView)customersTable[0];
        ListBox1.Items.Add(row["CustomerId"].ToString());
        ListBox1.Items.Add(row["Name"].ToString());
        ListBox1.Items.Add(row["Country"].ToString());
    }
