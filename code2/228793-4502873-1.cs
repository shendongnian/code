    private static void datatable_example() {
    
       string [] custids = {"ALFKI", "BONAP", "CACTU", "FRANK"};
    
       DataTable custid_list = new DataTable();
       custid_list.Columns.Add("custid", typeof(String));
    
       foreach (string custid in custids) {
          DataRow dr = custid_list.NewRow();
          dr["custid"] = custid;
          custid_list.Rows.Add(dr);
       }
    
       using(SqlConnection cn = setup_connection()) {
          using(SqlCommand cmd = cn.CreateCommand()) {
    
             cmd.CommandText =
               @"SELECT C.CustomerID, C.CompanyName
                 FROM   Northwind.dbo.Customers C
                 WHERE  C.CustomerID IN (SELECT id.custid FROM @custids id)";
             cmd.CommandType = CommandType.Text;
    
             cmd.Parameters.Add("@custids", SqlDbType.Structured);
             cmd.Parameters["@custids"].Direction = ParameterDirection.Input;
             cmd.Parameters["@custids"].TypeName = "custid_list_tbltype";
             cmd.Parameters["@custids"].Value = custid_list;
    
             using (SqlDataAdapter da = new SqlDataAdapter(cmd))
             using (DataSet        ds = new DataSet()) {
                da.Fill(ds);
                PrintDataSet(ds);
             }
          }
       }
    }
