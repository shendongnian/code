    using(System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand("INSERT INTO mytable (name, theblob) VALUES ('foo', @binaryValue)", conn))
    {
      cmd.Parameters.Add("@binaryValue", System.Data.SqlDbType.Text, 8000).Value = arraytoinsert;
      cmd.ExecuteNonQuery();
    }
