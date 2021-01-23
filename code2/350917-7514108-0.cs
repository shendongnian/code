    using (IConnection connection = factory.CreateConnection())
    {
        connection.start ();
    
         using (ISession session = connection.CreateSession())
         {
          //Whatever...
         }
    
    }
