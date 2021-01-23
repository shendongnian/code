    public class SomeClass
    {
        
        //Use parameters rather than accessing module level properties
        private IList<ColumnInformation> GetColumnInformationForTable(string dbName, string tableName)
        {
            // Favor object oriented styles and meaningful names.  Your method does not return a list of tables
            // it returns a list of column meta data
            List<ColumnInformation> columnInformations = new List<ColumnInformation>();
            // NEVER concatenate parameters into SQL commands and NEVER EVER with single quotes.
            // Here table name requires concatenation but the select parameter TableName does not.
            string selectCmdString = "SELECT column_name,data_type,character_maximum_length FROM " + dbName + ".information_schema.columns WHERE table_name = @TableName";
            
            // Use parameters.  Get everything ready first, don't open connections prematurely and only wrap error prone code in try blocks.
            SqlCommand cmd = new SqlCommand(selectCmdString, conn);
            SqlParameter tableNameParameter = new SqlParameter("@TableName", tableName);
            cmd.Parameters.Add(tableNameParameter);
            // Use a DataReader since you cannot modify this data anyway.
            // This also shows an appropriate use of a try block to ensure a connection gets closed, 
            // but better yet, open your reader with the CommandBehavior set to close
            // and get rid of this try block altogether
            try
            {
                //Reconsider use of a module or global level connection.  May be better to create a new here.
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                //Favor OOP styles rather than indexes and arrays and repeated calls to determine things like Rows.Count in a loop 
                while(reader.Read())
                {
                    // Favor explicit member access rather than index acess.
                    //YOUR HOMEWORK!  Study DataReader access and rewrite the code below to handle possible nulls in length field.  Use a method based on evaluating conditionals, DO NOT use a method based on a try block.
                    ColumnInformation columnInformation = new ColumnInformation(reader["column_name"].ToString(), reader["data_type"].ToString(), (int)reader["character_maximum_length"].ToString());
                    columnInformations.Add(columnInformation);
                }
                reader.Close();
            }
            finally
            {
                // The only reason to use the try is to make sure the connection gets closed here.  A better approach
                // is to use the CommandBehavior.CloseConnection option and get rid of the try finally block completely.
                // But NEVER just wrap a bunch of code in try blocks arbitrarily, swallow any errors and return a null.
                conn.Close();
            }
            
            return columnInformations;
        }
        
    }
    public class ColumnInformation
    {
        private string _columnName;
        private string _dataType;
        private int _columnLength;
        public string ColumnName
        {
            get { return _columnName; }
        }
        public string DataType
        {
            get { return _dataType; }
        }
        public int ColumnLength
        {
            get { return _columnLength; }
        }
        public ColumnInformation(string columnName, string dataType, int columnLength)
        {
            _columnName = columnName;
            _dataType = dataType;
            _columnLength = columnLength;
        }
    }
