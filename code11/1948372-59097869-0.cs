    class Program
        {
            static void Main(string[] args)
            {
                byte[] b = File.ReadAllBytes("D:\\2.xlsx");      // you get from the client
                File.WriteAllBytes("test.xlsx", b);             //Create an hourly file
                DataTable table = Exceltodatatable("test.xlsx");  // convert it to datatable
                File.Delete("test.xlsx");                         // delete the file
            }
    
            public static DataTable Exceltodatatable(string path)
            {
                DataTable dt = new DataTable();
                string connectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + path + ";" + "Extended Properties='Excel 12.0 Xml;HDR=YES;IMEX=1;MAXSCANROWS=0'";
                using (OleDbConnection conn = new OleDbConnection(connectionString))
                {
                    using (OleDbCommand comm = new OleDbCommand())
                    {
                        string sheetName = "sheet1";
                        comm.CommandText = "Select * from [" + sheetName + "$]";
                        comm.Connection = conn;
                        using (OleDbDataAdapter da = new OleDbDataAdapter())
                        {
                            da.SelectCommand = comm;
                            da.Fill(dt);
                            return dt;
                        }
                    }
    
                }
            }
        }
