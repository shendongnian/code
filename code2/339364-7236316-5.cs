        using(var cm = _dbConnection.CreateCommand())
        {
            cm.CommandText = @"Select * 
                               From table 
                               Where Id = @Id";
            cm.CommandType = CommandType.Text;
            cm.Parameter.AddWithValue("Id", id);
            cm.ExecuteNonQuery();
        }
