     using (var connection = factory.CreateConnection())
     {
          using (var channel = connection.CreateModel())
          {
                ....    
          }
     }
