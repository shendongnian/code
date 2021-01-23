    using MySql.Data.MySqlClient;
    using System.Data;
    using System.IO;
    using System.Text;
    
    namespace ImportDatabase
    {
        class DataTableToMySql
        {
            public MySqlConnection Connection { get; set; } 
            public DataTable SourceDataTable { get; set; } 
            public string FieldTerminator { get; set; }
            public string LineTerminator { get; set; }
    
            public DataTableToMySql(MySqlConnection conn, DataTable table)
            {
                FieldTerminator = "\t";
                LineTerminator = "\n";
    
                Connection = conn;
                SourceDataTable = table;
            }
    
            public void Execute()
            {
                string fileName = Path.GetTempFileName();
    
                try
                {
                    byte[] fieldTerm = Encoding.UTF8.GetBytes(FieldTerminator);
    
                    byte[] lineTerm = Encoding.UTF8.GetBytes(LineTerminator);
    
                    PrepareFile(fileName, fieldTerm, lineTerm);
    
                    LoadData(fileName);
                }
                finally
                {
                    File.Delete(fileName);
                }
            }
    
            private void LoadData(string fileName)
            {
                MySqlBulkLoader bl = new MySqlBulkLoader(Connection);
    
                bl.FieldTerminator = FieldTerminator;
    
                bl.LineTerminator = LineTerminator;
    
                bl.TableName = SourceDataTable.TableName;
    
                bl.FileName = fileName;
    
                bl.Load();
            }
    
            private void PrepareFile(string fileName, byte[] fieldTerm, byte[] lineTerm)
            {
                using (FileStream fs = new FileStream(fileName, FileMode.Append))
                {
                    foreach (DataRow row in SourceDataTable.Rows)
                    { 
                        int i = 0;
    
                        foreach (object val in row.ItemArray)
                        {
                            byte[] bytes;
                            if (val is DateTime)
                            {
                                DateTime theDate = (DateTime)val;
                                string dateStr = theDate.ToString("yyyy-MM-dd HH:mm:ss"); 
                                bytes = Encoding.UTF8.GetBytes(dateStr);
                            }
                            else
                                bytes = Encoding.UTF8.GetBytes(val.ToString());
    
                            fs.Write(bytes, 0, bytes.Length);
    
                            i++;
    
                            if (i < row.ItemArray.Length)
                                fs.Write(fieldTerm, 0, fieldTerm.Length);
                        }
    
                        fs.Write(lineTerm, 0, lineTerm.Length);
                    }
                }
            }
        }
    }
