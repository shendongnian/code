    private void InsertInfo()
    {
      var dateSelected = dpDate.SelectedItem.Value;
      using(SqlConnection conn = new SqlConnection(GetConnectionString()))
      {
           conn.Open();
           SqlCommand command= conn.CreateCommand();
           command.CommandText=     "INSERT INTO personTraining (name,training_id, training,trainingDate,trainingHour, trainingSession)SELECT @Val1,training_id,training,trainingDate,trainingHour,trainingSession FROM tbl_training WHERE  training_id = @trainingID";
    
          command.Parameters.AddWithValue("@trainingID",dateSelected);
          command.ExecuteNonQuery();
    }
