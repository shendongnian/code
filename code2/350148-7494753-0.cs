    protected void btnDownload_Click(object sender, EventArgs e)
    {
       MySqlConnection connection = new MySqlConnection(@"Data Source=localhost\SQLEXPRESS;Initial Catalog=PSeminar;Integrated Security=true;Trusted_Connection=Yes;MultipleActiveResultSets=true");
       MySqlCommand myCommand = myConn.CreateCommand();
       MySqlDataReader SQLRD;
       myCommand.CommandText = "SELECT * FROM Attendance";
       connection.Open();
       SQLRD = myCommand.ExecuteReader();
       string data="";
       while (SQLRD.Read())
       {
         data += "Row data, arrange how you want";//SQLRD[0].Tostring();-->first coloum
       }
       SQLRD.Close();
       connection.Close();
       string filename = "F:\file1.txt";  //with path
       FileStream fs = new FileStream(filename, FileMode.Append, FileAccess.Write);
       StreamWriter sw = new StreamWriter(fs);
       sw.WriteLine(data);
       sw.Flush();
       sw.Close();
       fs.Close();
    }
