    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Data.SqlClient;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    
    namespace sqlclienttest
    {
        class Program
        {
            static void Main(string[] args)
            {
                string tmpTable = @"create table #TempTable 
                                    (
                                    [Column1] [varchar](50) NOT NULL,
                                    [Column2] [varchar](50) NOT NULL,
                                    [Column3] [varchar](50) NOT NULL
                                    )";
                string connString = "Data Source=xxxx.database.windows.net;" +
                                        "Initial Catalog=Adventureworks;" +
                                        "User id=xxxxxx;" +
                                        "Password=xxxxxx;";
    
                var dataTable = new DataTable();
                dataTable.Columns.Add("Column1", typeof(string));
                dataTable.Columns.Add("Column2", typeof(string));
                dataTable.Columns.Add("Column3", typeof(string));
    
                dataTable.BeginLoadData();
                for (int i = 0; i < 10000; i++)
                {
                    var r = dataTable.NewRow();
                    r[0] = $"column1{i}";
                    r[1] = $"column2{i}";
                    r[2] = $"column3{i}";
                    dataTable.Rows.Add(r);
                }
                dataTable.EndLoadData();
    
                using (SqlConnection connection = new SqlConnection(connString))
                {
                    connection.Open();
                    SqlCommand cmd = new SqlCommand(tmpTable, connection);
                    cmd.ExecuteNonQuery();
    
                    try
                    {
                        using (SqlBulkCopy bulkCopy = new SqlBulkCopy(connection))
                        {
                            bulkCopy.NotifyAfter = 1000;
                            bulkCopy.SqlRowsCopied += (s, a) => Console.WriteLine($"{a.RowsCopied} rows");
                            bulkCopy.DestinationTableName = "#TempTable";
                            bulkCopy.WriteToServer(dataTable);
    
                            //string mergeSql = "<Will eventually have merge statement here>";
    
                            //cmd.CommandText = mergeSql;
                            //int results = cmd.ExecuteNonQuery();
    
                            cmd.CommandText = "DROP TABLE #TempTable";
                            cmd.ExecuteNonQuery();
                        }
                    }
                    catch (Exception)
                    {
                        throw;
                    }
   
   
                }
            }
        }
    }
