        public void Dotransfer()
        {
            var sourceSchema = new TableSchema(SourceConnectionString);
        }
 
      public class TableSchema
        {
            public TableSchema(string connectionString)
            {
                this.TableList = new List<string>();
                this.ColumnList = new List<Columns>();
                this.PrimaryKeyList = new List<PrimaryKey>();
                this.ForeignKeyList = new List<ForeignKey>();
                this.UniqueKeyList = new List<UniqueKey>();
    
                GetDataBaseSchema(connectionString);
    
            }
    
            public List<string> TableList { get; set; }
            public List<Columns> ColumnList { get; set; }
            public List<PrimaryKey> PrimaryKeyList { get; set; }
            public List<UniqueKey> UniqueKeyList { get; set; }
            public List<ForeignKey> ForeignKeyList { get; set; }
    
    
            protected void GetDataBaseSchema(string ConnectionString)
            {
                using (SqlConnection connection = new SqlConnection(ConnectionString))
                {
    
                    System.Data.SqlClient.SqlConnectionStringBuilder builder = new System.Data.SqlClient.SqlConnectionStringBuilder();
                    builder.ConnectionString = ConnectionString;
                    string server = builder.DataSource;
                    string database = builder.InitialCatalog;
    
                    connection.Open();
    
    
                    DataTable schemaTables = connection.GetSchema("Tables");
    
                    foreach (System.Data.DataRow rowTable in schemaTables.Rows)
                    {
                        String tableName = rowTable.ItemArray[2].ToString();
                        this.TableList.Add(tableName);
    
                        string[] restrictionsColumns = new string[4];
                        restrictionsColumns[2] = tableName;
                        DataTable schemaColumns = connection.GetSchema("Columns", restrictionsColumns);
    
                        foreach (System.Data.DataRow rowColumn in schemaColumns.Rows)
                        {
                            string ColumnName = rowColumn[3].ToString();
                            this.ColumnList.Add(new Columns(){TableName= tableName, FieldName = ColumnName});
                        }
    
                        string[] restrictionsPrimaryKey = new string[4];
                        restrictionsPrimaryKey[2] = tableName;
                        DataTable schemaPrimaryKey = connection.GetSchema("IndexColumns", restrictionsColumns);
    
    
                        foreach (System.Data.DataRow rowPrimaryKey in schemaPrimaryKey.Rows)
                        {
                            string indexName = rowPrimaryKey[2].ToString();
    
                            if (indexName.IndexOf("PK_") != -1)
                            {
                                this.PrimaryKeyList.Add(new PrimaryKey()
                                {
                                    TableName = tableName,
                                    FieldName = rowPrimaryKey[6].ToString(),
                                    PrimaryKeyName = indexName
                                });
                            }
    
                            if (indexName.IndexOf("UQ_") != -1)
                            {
                                this.UniqueKeyList.Add(new UniqueKey()
                                {
                                    TableName = tableName,
                                    FieldName = rowPrimaryKey[6].ToString(),
                                    UniqueKeyName = indexName
                                });
                            }
                                
                        }
                        
    
                        string[] restrictionsForeignKeys = new string[4];
                        restrictionsForeignKeys[2] = tableName;
                        DataTable schemaForeignKeys = connection.GetSchema("ForeignKeys", restrictionsColumns);
    
    
                        foreach (System.Data.DataRow rowFK in schemaForeignKeys.Rows)
                        {
    
                            this.ForeignKeyList.Add(new ForeignKey()
                            {
                                ForeignName = rowFK[2].ToString(),
                                TableName = tableName,
                                // FieldName = rowFK[6].ToString() //There is no information
                            });                
                        }
    
    
                    }
    
    
                }
    
            }
    
        }    
    
        public class Columns
        {
            public string TableName { get; set; }
            public string FieldName { get; set; }
        }
    
        public class PrimaryKey
        {
            public string TableName { get; set; }
            public string PrimaryKeyName { get; set; }
            public string FieldName { get; set; }
        }
    
    
        public class UniqueKey
        {
            public string TableName { get; set; }
            public string UniqueKeyName { get; set; }
            public string FieldName { get; set; }
        }
    
        public class ForeignKey
        {
            public string TableName { get; set; }
            public string ForeignName { get; set; }
           // public string FieldName { get; set; } //There is no information
        }
