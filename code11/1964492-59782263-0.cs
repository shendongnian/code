    ..
    SqlConnection sqlcon = new SqlConnection(cs);
    sqlcon.Open();
    SqlCommand cmd = new SqlCommand(sql, sqlcon);
    cmd.Parameters.AddWithValue("@pric", pric);
    cmd.Parameters.AddWithValue("@id", id);
    int result = cmd.ExecuteNonQuery();            
    sqlcon.Close();
    if(result > 0){
      // update is successfull
    }
