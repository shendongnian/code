    public Cust
    {
       SqlConnection channel=new SqlConnection();
       SqlCommand command;//=new SqlCommand();
    
       public void Method()
       {
           using(connect con=new connect())
             {
             con.OpenChannel(channel);
             //command.connection=channel;
            
             // create command from open connection
             command = channel.CreateCommand();
             .....
             ....
             ....
             command.ExecuteNonQuery();
             }
       }
