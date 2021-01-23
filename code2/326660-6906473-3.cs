    private void button1_click(object server, EventArg args)
    {
        using ( var connection = ConnectionFactory.Create() )
        {
           connection.Execute("...");
        }
    }
