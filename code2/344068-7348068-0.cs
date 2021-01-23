        protected string ImageCheck()
        {
        
          var result = new StringBuilder();
    
        using(var connection = new SqlConnection(@"Data Source=.\SQLEXPRESS;AttachDbFilename=|DataDirectory|\***.mdf;Integrated Security=True;Connect Timeout=30;User Instance=True"))
        {
            string CommandText2 = "SELECT * FROM Machreta WHERE noImage = 1";
            SqlCommand command2 = new SqlCommand(CommandText2, connection);
            connection.Open();
        
          using(var reader = command2.ExecuteReader())
          {
            while (reader.Read())
            {
              result.Append(reader.GetString(0));
            }
          }
        
          return result.ToString();
    
        }
     }
