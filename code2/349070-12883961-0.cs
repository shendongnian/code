    SqlConnection SqlCon = new SqlConnection("Data Source=(local);Database=  dbname;Integrated Security=SSPI;");
    SqlDataReader SqlDr;
    SqlCon.Open();
    SqlCmd = SqlCon.CreateCommand();
    SqlCmd.CommandText = "select * from Tablename";
    SqlDr = SqlCmd.ExecuteReader();
    SqlDr.Read();
    int i=0;
    while (i < SqlDr.FieldCount)
    { MessageBox.Show(SqlDr.GetDataTypeName(i)); i++;}'
