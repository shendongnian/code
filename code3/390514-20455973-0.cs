    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Data.OleDb;
    namespace oleDbTest
    {
        class Program
        {
            static void Main(string[] args)
            {
                string myConnectionString;
                myConnectionString =
                        @"Provider=Microsoft.ACE.OLEDB.12.0;" +
                        @"Data Source=C:\Users\Public\Database1.accdb;";
                using (var con = new OleDbConnection())
                {
                    con.ConnectionString = myConnectionString;
                    con.Open();
                    using (OleDbDataAdapter da = new OleDbDataAdapter())
                    using (OleDbCommandBuilder bld = new OleDbCommandBuilder(da))
                    {
                        bld.QuotePrefix = "[";  // these are
                        bld.QuoteSuffix = "]";  //   important!
                        da.SelectCommand = new OleDbCommand(
                                "SELECT [ID], [Name], [Money] " +
                                "FROM [Test] " +
                                "WHERE False",
                                con);
                        using (System.Data.DataTable dt = new System.Data.DataTable("Test"))
                        {
                            // create an empty DataTable with the correct structure
                            da.Fill(dt);
                            System.Data.DataRow dr = dt.NewRow();
                            dr["Name"] = "Huber";
                            dr["Money"] = 100;
                            dt.Rows.Add(dr);
                            
                            da.Update(dt);  // write new row back to database
                        }
                    }
                    con.Close();
                }
                Console.WriteLine();
                Console.WriteLine("Done.");
            }
        }
    }
