    public class DBhelperClass
    {
        string dbConnection = "Data Source=ShyamDB.s3db";
        public DataTable GetDataTable(string sql) {
            DataTable dt = new DataTable();
            try {
                SQLiteConnection cnn = new SQLiteConnection(dbConnection);
                cnn.Open();
                SQLiteCommand mycommand = new SQLiteCommand(cnn);
                mycommand.CommandText = sql;
                SQLiteDataReader reader = mycommand.ExecuteReader();
                dt.Load(reader);
                reader.Close();
                cnn.Close();
            } catch (Exception e) {
                throw new Exception(e.Message);
            }
        return dt;
        }
    }
    
    //string   nputFile = "ShyamDB.s3db" is mydb name ;
    DBhelperClass db = new  DBhelperClass(); 
    dataGridView1.DataSource = db.GetDataTable("Select * from ShyamTable");
