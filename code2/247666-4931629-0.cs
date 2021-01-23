    private void DoMyPieceOfWork(int value1, int value2)
    {
        using(MySqlConnection connection = new MySqlConnection(
          CONNECTION_STRING_GOES_HERE))
        {   
            connection.Open();
            using(MySqlCommand command = new MySqlCommand(
              "INSERT INTO TABLE `blah` (Column1, Column2) VALUES @column1, @column2"))
            {
                command.Parameters.Add("@column1", MySqlType.Int).Value = value1; 
                command.Parameters.Add("@column2", MySqlType.Int).Value = value2; 
                command.ExecuteNonQuery();
            }
            connection.Close();   
        }
    }
