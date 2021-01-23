    using System;
    using ADOX;
    using System.Data.OleDb;
    using System.Data;
    using System.IO;
    namespace ConsoleApplication4
    {
    class Program
    {
        static void Main(string[] args)
        {
            CreateMdb("toster_ru.mdb");
            string fileNameWithPath = Environment.CurrentDirectory + "\\toster_ru.mdb";
            CreateTableInToMdb(fileNameWithPath);
            InsertToMdb(fileNameWithPath);
            UpdateToMdb(fileNameWithPath);
            var myDataTable = new DataTable();
            using (var conection = new OleDbConnection("Provider = Microsoft.JET.OLEDB.4.0;  Data Source = " + fileNameWithPath))
            {
                conection.Open();
                var query = "Select info From my_table";
                var adapter = new OleDbDataAdapter(query, conection);
                adapter.Fill(myDataTable); 
                Console.WriteLine(myDataTable.Rows[0][0].ToString()); //output: toster2.ru
                Console.ReadKey();
            }
        }
        static void CreateMdb(string fileNameWithPath)
        {
            if (File.Exists(fileNameWithPath))
                return;
            Catalog cat = new Catalog();
            string connstr = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source={0};Jet OLEDB:Engine Type=5";
            cat.Create(String.Format(connstr, fileNameWithPath));
            cat = null; 
        }
        static void InsertToMdb(string fileNameWithPath)
        {
            var con = new OleDbConnection("Provider = Microsoft.Jet.OLEDB.4.0; Data Source = " + fileNameWithPath);
            var cmd = new OleDbCommand();
            cmd.Connection = con;
            cmd.CommandText = "insert into my_table (ID, [Info], [text])  values (@ID, @Info, @text);";
            cmd.Parameters.AddWithValue("@ID", 1);
            cmd.Parameters.AddWithValue("@Info", "toster.ru");
            cmd.Parameters.AddWithValue("@text", "blabla");
            con.Open(); 
            cmd.ExecuteNonQuery();
            con.Close();
        }
        static void UpdateToMdb(string fileNameWithPath)
        {
            var con = new OleDbConnection("Provider = Microsoft.Jet.OLEDB.4.0; Data Source = " + fileNameWithPath);
            var cmd = new OleDbCommand();
            cmd.Connection = con;
            cmd.CommandText = "UPDATE my_table SET [Info] = ?, [text] = ? WHERE ID = ?;";
            cmd.Parameters.AddWithValue("@p1", OleDbType.VarChar).Value = "toster2.ru";
            cmd.Parameters.AddWithValue("@p2", OleDbType.VarChar).Value = "blabla2";
            cmd.Parameters.AddWithValue("@p3", OleDbType.VarNumeric).Value = 1;
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
        }
        static void CreateTableInToMdb(string fileNameWithPath)
        {
            try
            {
                OleDbConnection myConnection = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0; Data Source=" + fileNameWithPath);
                myConnection.Open();
                OleDbCommand myCommand = new OleDbCommand();
                myCommand.Connection = myConnection;
                myCommand.CommandText = "CREATE TABLE my_table([ID] NUMBER, [Info] TEXT, [text] TEXT)";
                myCommand.ExecuteNonQuery();
                myCommand.Connection.Close();
            }
            catch { }
        }
    }
    }
