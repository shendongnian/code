    //Open connection
    string conString = "server=myserver; Uid=myusername; database=myscheme; Pwd=mypwd; Allow User Variables=True";
    MySqlConnection con = new MySqlConnection(conString);
    try
    {
        //Open connection
        con.Open();
        
        //Set first variable, @START
        //Set second variable, @END
        //Send procedure call
        string sql = "SET @START = '" + date1 + "';" +
                     "SET @END   = '" + date2 + "';" +
                     "CALL MY_DB_PROCEDURE";
        MySqlDataAdapter MyDA = new MySqlDataAdapter();
        MyDA.SelectCommand = new MySqlCommand(sql, con);        
        //From here you can process the DB response as you like
        //...
    }
    catch (Exception e)
    {
        //Error handling procedure
    }
    finally
    {
        if (con.State == ConnectionState.Open)
        {
            con.Dispose(); // return connection to the pool
        }
    }
