    protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
    {
    if(-1 != DropDownList1.SelectedIndex)
    {
    using(SqlConnection connection = new SqlConnection("connectionString"))
    {
    connection.Open();
    using(SqlCommand command = new SqlCommand("SELECT A.CUSTOMERNUMBER FROM CUSTOMER A, SALES B WHERE B.CUSTOMERNAME = @CustomerName"))
    {
    command.Connection = connection;
    command.Parameters.AddWithValue("@CustomerName", DropDownlist1.SelectedValue.ToString());
    this.Label1.Text = command.ExecuteScalar().ToString();
    }
    }
    }
    }
