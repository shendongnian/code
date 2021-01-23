    string sqlquery = "select * from person"; 
    DataGridView1.DataSource = PullTableResults(sqlquery);
	private static DataTable PullTableResults(string sqlquery)
    {
       try
       {
           if (showMessages)
           {
               MessageBox.Show(sqlquery);
           }
           
           var conn = new OracleConnection(Oradb);
           conn.Open();
           var cmd = new OracleCommand(sqlquery, conn);
           cmd.CommandType = CommandType.Text;
           var dr = cmd.ExecuteReader();
           var read = dr.Read();
           var table = new DataTable();
           var oda = new OracleDataAdapter(cmd);
           int fill = oda.Fill(table);
           conn.Close();
           conn.Dispose();
           return table;
       }
       catch (Exception ex)
       {
           const string Message = "Database Exception";
           if (showMessages)
           {
               MessageBox.Show(Message + ex);
           }
           var table = new DataTable();
           return table; // return empty table cause there was error
       }
   }
