    if(txtNAME.Text.Trim()!=String.Empty&&txtPRICE.Text.Trim()!=String.Empty)
    {
      MessageBox.Show("Invalid type of input","Alert", MessageBoxButtons.OK, MessageBoxIcon.Error);
    }
    else
    {
      SqlConnection _sqlconnectionOne=new SqlConnection(*DatabaseConnectionString*)
      SqlCommand _sqlcommandOne=new SqlCommand();
      _sqlcommandOne.CommandType=CommandType.Text;
      _sqlcommandOne.CommandText="*INSERTStatement*";
      _sqlcommandOne.Connection=_sqlconnectionOne;
      _sqlcommandOne.ExecuteNonQuery();
      SqlConnection _sqlconnectionSecond=new SqlConnection(*DatabaseConnectionString*)
      SqlCommand _sqlcommandSecond=new SqlCommand();
      _sqlcommandSecond.CommandType=CommandType.Text;
      _sqlcommandSecond.CommandText="*SELECT*Statement*";
      _sqlcommandSecond.Connection=_sqlconnectionSecond;
      SqlDataAdapter _sqldataadapter=new SqlDataAdapter(_sqlcommandSecond);
      DataTable _datatable=new DataTable();
      _sqldataadapter.fill(_datatable);
      *DataGridViewName*.DataSource=_datatable;
    }
