    public void GetCustomerList(DataGridView customerList)
    {
        using (var cmd = new SqlCommand("usp_GetCustomer", Con.GetConnection()))
        {
            cmd.CommandType = CommandType.StoredProcedure;
            using (var sda = new SqlDataAdapter(cmd))
            {
                sda.Fill(dtTable);
                customerList.DataSource = dtTable ;
            }
        }
        return;
    }
