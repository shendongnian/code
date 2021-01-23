    string query = "SELECT StudentID FROM Student WHERE APID = @APID AND Semester  = @Semester AND Roll_No = @RollNo";
    using(SqlConnection _con = new SqlConnection(@"Data Source=.\SQLEXPRESS;Initial Catalog=Examination_Cell;Integrated Security=True"))
    using(SqlCommand _cmd = new SqlCommand(query, _con))
    {
       _cmd.Parameters.Add("@APID", SqlDbType.Int).Value = ......;
       _cmd.Parameters.Add("@Semester", SqlDbType.Int).Value = ......;
       _cmd.Parameters.Add("@RollNo", SqlDbType.Int).Value = ......;
       _con.Open();
       using(SqlDataReader reader = _cmd.ExecuteReader())
       {
           while (reader.Read())
           {
              // do something
           }
       }
       _con.Close();
    }
