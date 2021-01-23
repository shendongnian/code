    string sSQL = "SELECT * FROM Products";
    string sConnString = 
        "Server=(local);Database=Northwind;Integrated Security=SSPI;";
    SqlDataAdapter oDa = new SqlDataAdapter();
    DataSet oDs = new DataSet();
    using(SqlConnection oCn = new SqlConnection(sConnString))
    {
        SqlCommand oSelCmd = new SqlCommand(sSQL, oCn);
        oSelCmd.CommandType = CommandType.Text;
        oDa.SelectCommand = oSelCmd;
        oDa.Fill(oDs, "Products");
    }
