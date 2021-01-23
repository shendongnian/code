    public class ExcelDataManager
    {
        public string ConnectionString { get; set; }
        public ExcelDataManager(string connectionString)
        {
            this.ConnectionString = connectionString;
        }
        public DataSet LoadDataSet(string commandText, string dataSetName, string tableName)
        {
            return LoadDataSet(this.ConnectionString, commandText, dataSetName, tableName);
        }
        public static DataSet LoadDataSet(string connectionString, string commandText, string dataSetName, string tableName)
        {
            DataSet oResult = null;
            DataTable oDataTable = LoadDataTable(connectionString, commandText, tableName);
            if (oDataTable != null)
            {
                string sDataSetName = dataSetName;
                if (string.IsNullOrWhiteSpace(dataSetName))
                {
                    sDataSetName = "DataSet1";
                }
                oResult = new DataSet(sDataSetName);
                oResult.Tables.Add(oDataTable);
                oResult.AcceptChanges();
            }
            return oResult;
        }
        public DataTable LoadDataTable(string commandText, string tableName)
        {
            return LoadDataTable(this.ConnectionString, commandText, tableName);
        }
        public static DataTable LoadDataTable(string connectionString, string commandText, string tableName)
        {
            DataTable oResult = null;
            using (OleDbConnection oConnection = new OleDbConnection(connectionString))
            {
                using (OleDbCommand oCommand = oConnection.CreateCommand())
                {
                    oCommand.CommandType = CommandType.Text;
                    oCommand.CommandText = commandText;
                    oCommand.Connection.Open();
                    using (OleDbDataReader oReader = oCommand.ExecuteReader(CommandBehavior.CloseConnection))
                    {
                        if (oReader.HasRows)
                        {
                            // You need a table name if you call WriteXml.
                            string sTableName = tableName;
                            if (string.IsNullOrWhiteSpace(tableName))
                            {
                                sTableName = "Table1";
                            }
                            oResult = new DataTable(sTableName);
                            oResult.Load(oReader);
                            oResult.AcceptChanges();
                        }
                    }
                }
            }
            return oResult;
        }
    }
