    public class ViewModel
    {
      public DataTable Data { get; set; }
    
      public ViewModel()
      {
        this.Data = new DataTable();
      }
      // Button ICommand handler
      private void ExecuteGetDataCommand(object param)
      {
        DataTable dataTable = QueryDatabase(); 
    
        // Filter DataTable using LINQ
        this.Data = dataTable
          .AsEnumerable()
          .Where(row => row["NRO"].ToString().StartsWith("3")
            && row["ACTIVE"].ToString().StartsWith("1"))
          .CopyToDataTable();
      }
      private DataTable QueryDatabase()
      {
        OdbcConnection dbConnection = new OdbcConnection("Driver={Pervasive ODBC Client Interface};ServerName=875;dbq=@DBFS;Uid=Username;Pwd=Password;");
        string strSql = "select NRO,NAME,NAMEA,NAMEB,ADDRESS,POSTA,POSTN,POSTADR,COMPANYN,COUNTRY,ID,ACTIVE from COMPANY";
        dbConnection.Open();
        OdbcDataAdapter dadapter = new OdbcDataAdapter();
        dadapter.SelectCommand = new OdbcCommand(strSql, dbConnection);
        DataTable table = new DataTable("COMPANY");
        dadapter.Fill(table);
        return table;
      }
    }
