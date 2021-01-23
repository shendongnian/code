    using System;
    using System.Data;
    using Oracle.DataAccess.Client;
    static class Program
    {
        [STAThread]
        static void Main()
        {
            TestOracle();
        }
        private static void TestOracle()
        {
            string connString = 
                "Data Source=(DESCRIPTION=(ADDRESS_LIST=(ADDRESS=(PROTOCOL=TCP)" + 
                "(HOST=servername)(PORT=‌​1521)))" +
                "(CONNECT_DATA=(SERVER=DEDICATED)(SERVICE_NAME=servicename)));"+ 
                "User Id=username;Password=********;";
            using (OracleConnection conn = new OracleConnection(connString))
            {
                string sqlSelect = "SELECT * FROM TEST_TABLE";
                using (OracleDataAdapter da = new OracleDataAdapter(sqlSelect, conn))
                {
                    var table = new DataTable();
                    da.Fill(table);
                    if (table.Rows.Count > 1) 
                        Console.WriteLine("Successfully read oracle.");
                }
            }
        }
    }
