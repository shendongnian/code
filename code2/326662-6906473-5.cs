    private void button1_click(object sender, EventArg args)
    {
        using ( var connection = ConnectionFactory.Create() )
        {
           connection.Execute("...");
        }
    }
