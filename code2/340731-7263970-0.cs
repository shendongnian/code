    using (var cn = new SqlClient.SqlConnection(yourConnectionString))
    using (var cmd = new SqlClient.SqlCommand())
    {
       cn.Open();
       cmd.Connection = cn;
       cmd.CommandType = CommandType.Text;
       cmd.CommandText = "Select * From Table Where Title = @Title";
       cmd.Parameters.Add("@Title", someone);
    }
